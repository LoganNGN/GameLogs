using Newtonsoft.Json;

internal class APIConnector
{
    private readonly HttpClient client;
    private readonly string apiKey;

    public APIConnector()
    {
        string apiKeyPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "source", "repos", "GameLogs", "GameLogs", "apikey.txt");
        apiKey = File.ReadAllText(apiKeyPath);
        client = new HttpClient();
    }
    public class GameInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Screenshots { get; set; } = new List<string>();
    }

    public async Task ProcessGames(string[] gameNames)
    {
        foreach (string gameName in gameNames)
        {
            HttpResponseMessage response = await client.GetAsync($"https://api.rawg.io/api/games/{gameName}?key={apiKey}");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();

                // Convert game data to JSON format
                dynamic gameData = JsonConvert.DeserializeObject(responseBody);
                GameInfo gameInfo = new GameInfo
                {
                    Id = gameData.id,
                    Name = gameData.name,
                    Description = gameData.description,
                    Screenshots = new List<string>()
                };

                await RetrieveScreenshots(gameName, gameInfo);

                string jsonData = JsonConvert.SerializeObject(gameInfo, Formatting.Indented);

                // Write JSON data to a file
                string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "source", "repos", "GameLogs", "GameLogs", "Results", $"{gameName}.json");
                try
                {
                    using (StreamWriter writer = new StreamWriter(fileName))
                    {
                        writer.Write(jsonData);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error saving game data to file: {e.Message}");
                    Console.WriteLine($"Stack trace: {e.StackTrace}");
                }
            }
            else
            {
                Console.WriteLine($"Game '{gameName}' does not exist");
            }
        }
    }

    private async Task RetrieveScreenshots(string gameName, dynamic gameInfo)
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
                    await Task.Delay(1000);
                }
            }

            // Update gameInfo with screenshot URLs
            gameInfo.Screenshots = screenshotUrls;
        }
        else
        {
            Console.WriteLine($"Failed to retrieve screenshots for game '{gameName}'");
        }
    }
}
