using System.Net.Http;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace GameLogs
{
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
                    var gameInfo = new { id = gameData.id, name = gameData.name, description = gameData.description };
                    string jsonData = JsonConvert.SerializeObject(gameInfo, Formatting.Indented);

                    // Write JSON data to a file
                    string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "source", "repos", "GameLogs", "GameLogs", gameName, $"{gameName}.json");
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
                    }
                }
                else
                {
                    Console.WriteLine($"Game '{gameName}' does not exist");
                }
            }
        }
    }
}