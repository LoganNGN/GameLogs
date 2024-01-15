using Newtonsoft.Json;

internal class APIConnector
{
    private readonly HttpClient client;
    private readonly string apiKey;
    private readonly string basePath;
    public APIConnector()
    {
        basePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "source", "repos", "GameLogs", "GameLogs");
        string apiKeyPath = Path.Combine(basePath, "apikey.txt");
        apiKey = File.ReadAllText(apiKeyPath);
        client = new HttpClient();
    }

    public class GameInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string BackgroundImage { get; set; }
        public List<string> Screenshots { get; set; } = new List<string>();
         
        public GameInfo(dynamic gameData)
        {
            Id = gameData.id;
            Name = gameData.name;
            Description = gameData.description;
            BackgroundImage = gameData.background_image;
        }

        public void AddScreenshots(List<string> screenshots)
        {
            Screenshots = screenshots;
        }
    }
    public Dictionary<string, object> GetGameData(GameInfo gameinfo, string tableName)
    {
        Dictionary<string, object> gameData = new Dictionary<string, object>()
            {
                {"tableName", tableName},
                { "Id", gameinfo.Id },
                { "Name", gameinfo.Name },
                { "Description", gameinfo.Description },
                { "BackgroundImage", gameinfo.BackgroundImage }
            };

        return gameData;
    }

    public async Task ProcessGames(string[] gameNames)
    {
        foreach (string gameName in gameNames)
        {
            var gameInfo = await GetGameInfo(gameName);
            if (gameInfo != null)
            {
                Dictionary<string, object> gameData = GetGameData(gameInfo, "Games");
                

                await WriteToFile(gameName, gameInfo);
            }
            else
            {
                throw new GameNotFoundException("le jeu n'a pas été trouver");
            }
        }
    }

    public async Task<GameInfo> GetGameInfo(string gameName)
    {
        HttpResponseMessage response = await client.GetAsync($"https://api.rawg.io/api/games/{gameName}?key={apiKey}");
        if (response.IsSuccessStatusCode)
        {
            string responseBody = await response.Content.ReadAsStringAsync();

            dynamic gameData = JsonConvert.DeserializeObject(responseBody);
            GameInfo gameInfo = new GameInfo(gameData);

            var screenshots = await RetrieveScreenshots(gameName);
            gameInfo.AddScreenshots(screenshots);

            return gameInfo;
        }
        else
        {
            throw new GameNotFoundException($"Game '{gameName}' does not exist");
        }
    }

    private async Task<List<string>> RetrieveScreenshots(string gameName)
    {
        HttpResponseMessage screenshotResponse = await client.GetAsync($"https://api.rawg.io/api/games/{gameName}/screenshots?key={apiKey}");
        if (screenshotResponse.IsSuccessStatusCode)
        {
            string screenshotResponseBody = await screenshotResponse.Content.ReadAsStringAsync();

            dynamic screenshotData = JsonConvert.DeserializeObject(screenshotResponseBody);

            List<string> screenshotUrls = new List<string>();
            int count = 0;
            foreach (dynamic screenshot in screenshotData.results)
            {
                if (count < 3)
                {
                    screenshotUrls.Add(screenshot.image.ToString());
                    count++;
                }
            }

            return screenshotUrls;
        }
        else
        {
            throw new ScreenshotRetrievalException($"Failed to retrieve screenshots for game '{gameName}'");
        }
    }


    public async Task WriteToFile(string gameName, GameInfo gameInfo)
    {
        string jsonData = JsonConvert.SerializeObject(gameInfo, Formatting.Indented);

        string fileName = Path.Combine(basePath, "Results", $"{gameName}.json");
        try
        {
            await File.WriteAllTextAsync(fileName, jsonData);
        }
        catch (Exception e)
        {
            throw new WriteInFileException($"Error Writing data to gameFile: {e.Message}", e);
        }
    }

    #region public attributes
    public class GameNotFoundException : Exception
    {
        public GameNotFoundException(string message) : base(message) { }
    }

    public class ScreenshotRetrievalException : Exception
    {
        public ScreenshotRetrievalException(string message) : base(message) { }
    }

    public class WriteInFileException : Exception
    {
        public WriteInFileException(string message, Exception innerException) : base(message, innerException) { }
    }

    #endregion public attributes
}