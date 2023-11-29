namespace GameLogs
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Initialize application configuration
            ApplicationConfiguration.Initialize();

            // Run the API Connector
            APIConnector apiConnector = new APIConnector();
            string[] gameNames = File.ReadAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "source", "repos", "GameLogs", "GameLogs", "games.txt"));
            apiConnector.ProcessGames(gameNames).Wait();
        }
    }
}
