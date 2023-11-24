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

            // Create an instance of the APIConnector class
            APIConnector connector = new APIConnector();

            // Define an array of game names to process
            string[] gameNames = new string[] { "overwatch", "fortnite", "apex_legends" };

            // Process the games and save their data to JSON files
            connector.ProcessGames(gameNames);

            // Run the Windows Forms application
            Application.Run(new Form1());
        }
    }
}
