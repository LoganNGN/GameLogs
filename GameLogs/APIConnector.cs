using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

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

    public async Task ProcessGames(string[] gameNames)
    {
        foreach (string gameName in gameNames)
        {
            var gameInfo = await GetGameInfo(gameName);
            if (gameInfo != null)
            {
                await WriteToFile(gameName, gameInfo);
            }
        }
    }

    private async Task<GameInfo> GetGameInfo(string gameName)
    {
        HttpResponseMessage response = await client.GetAsync($"https://api.rawg.io/api/games/{gameName}?key={apiKey}");
        if (response.IsSuccessStatusCode)
        {
            string responseBody = await response.Content.ReadAsStringAsync();

            // Convert game data to JSON format
            dynamic gameData = JsonConvert.DeserializeObject(responseBody);
            GameInfo gameInfo = new GameInfo(gameData);

            var screenshots = await RetrieveScreenshots(gameName);
            gameInfo.AddScreenshots(screenshots);

            return gameInfo;
        }
        else
        {
            Console.WriteLine($"Game '{gameName}' does not exist");
            return null;
        }
    }

    private async Task<List<string>> RetrieveScreenshots(string gameName)
    {
        HttpResponseMessage screenshotResponse = await client.GetAsync($"https://api.rawg.io/api/games/{gameName}/screenshots?key={apiKey}");
        if (screenshotResponse.IsSuccessStatusCode)
        {
            string screenshotResponseBody = await screenshotResponse.Content.ReadAsStringAsync();

            // Convert screenshot data to JSON format
            dynamic screenshotData = JsonConvert.DeserializeObject(screenshotResponseBody);

            // Extract screenshot URLs and convert them to strings
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
            Console.WriteLine($"Failed to retrieve screenshots for game '{gameName}'");
            return new List<string>();
        }
    }

    private async Task WriteToFile(string gameName, GameInfo gameInfo)
    {
        string jsonData = JsonConvert.SerializeObject(gameInfo, Formatting.Indented);

        // Write JSON data to a file
        string fileName = Path.Combine(basePath, "Results", $"{gameName}.json");
        try
        {
            await File.WriteAllTextAsync(fileName, jsonData);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error saving game data to file: {e.Message}");
            Console.WriteLine($"Stack trace: {e.StackTrace}");
        }
    }
}
