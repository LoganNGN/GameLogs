using System.Data;
using GameLogs.apiDataCollection;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace GameLogs
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>

        private static ApiData ApiData;
        

        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
            InsertQuery(ApiData);
        }
       
        private static int ExecuteWrite(string query, Dictionary<string, object> args)
        {
            int numberOfRowsAffected;
            string connString = "server=localhost;user=DBGameLogs;database=mydb;port=3306;password=Pa$$W0rd;";
            //setup the connection to the database
            using (var con = new MySqlConnection(connString))
            {
                con.Open();
                //open a new command
                using (var cmd = new MySqlCommand(query, con))
                {
                    //set the arguments given in the query
                    foreach (var pair in args)
                    {
                        cmd.Parameters.AddWithValue(pair.Key, pair.Value);
                    }
                    //execute the query and get the number of row affected
                    numberOfRowsAffected = cmd.ExecuteNonQuery();
                }
                return numberOfRowsAffected;
            }          
        }

        #region CRUD
        private static int InsertQuery(ApiData apiData)
        {
            string fileName = "C:\\Users\\pb34nwq\\source\\repos\\GameLogs\\GameLogs\\fortnite.json";
            string Json = File.ReadAllText(fileName);

            //prepare the query
            JsonConvert.DeserializeObject<ApiData>(Json);
            //TODO add value parameters
            string query = "INSERT INTO Game (id, name, description, image, gameState)" + " VALUES(@id, @name, @description, @image, @gameState );";

            //parameters
            //TODO figure out how to implement the bool gameState
            var args = new Dictionary<string, object>()
            {
                {"@id", apiData.Id}, {"@name", apiData.Name}, {"@description", apiData.Description}, {"@image", apiData.Image}
            };

            return ExecuteWrite(query, args);
        }

        //add in method parameter the data value of the form
        private static int UpdateQuery(ApiData apiData)
        {
            //prepare the query
            //TODO switch case statement for when we want to update the state of the game (todo or finished)
            //TODO add value parameters
            string query = "UPDATE INTO Game SET gameState = 'False' WHERE id = '@id';";

            //parameter
            var args = new Dictionary<string, object>()
            {
                {"@id", apiData.Id }
            };
            return ExecuteWrite(query, args);
        }


        #endregion
    }
}