using Newtonsoft.Json;
using RawgNET.Manager;
using RawgNET.Models;

namespace GameLogs
{
    internal class APIConnector
    {
        private readonly RawgClient client;
        private readonly string apiKey;

        public APIConnector()
        {
            string apiKeyPath = "C:\\Users\\tschi\\source\\repos\\GameLogs\\GameLogs\\apikey.txt";
            apiKey = File.ReadAllText(apiKeyPath);
            client = new(new ClientOptions(apiKey));
        }

        public async Task ProcessGames(string[] gameNames)
        {
            foreach (string gameName in gameNames)
            {
                if (await client.IsGameExisting(gameName))
                {
                    // Fetch detailed information about the game
                    Game game = await client.GetGame(gameName, true, true);

                    // Convert game data to JSON format
                    string jsonData = JsonConvert.SerializeObject(game, Formatting.Indented);

                    // Write JSON data to a file
                    string fileName = $"{gameName}.json";
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
