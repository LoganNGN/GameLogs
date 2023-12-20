using System.Data;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace GameLogs
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static APIConnector.GameInfo gameInfo = new APIConnector.GameInfo(gameData);
        private static dynamic gameData;

        [STAThread]
        static void Main()
        {
            // Initialize application configuration
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
            // Run the API Connector
            APIConnector apiConnector = new APIConnector();
            string[] gameNames = File.ReadAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "source", "repos", "GameLogs", "GameLogs", "games.txt"));
            apiConnector.ProcessGames(gameNames);
            //run Query's
            //SelectAllQuery();
            InsertQuery(gameInfo);
        }
        #region DataBase execute Methods
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

        private static DataTable ExecuteRead(string query, Dictionary<string, object> args)
        {
            string connString = "server=localhost;user=DBGameLogs;database=mydb;port=3306;password=Pa$$W0rd;";
            if (string.IsNullOrEmpty(query.Trim()))
            {
                return null;
            }
            using (var con = new MySqlConnection(connString))
            {
                con.Open();
                using (var cmd = new MySqlCommand(query, con))
                {
                    foreach (KeyValuePair<string, object> entry in args)
                    {
                        cmd.Parameters.AddWithValue(entry.Key, entry.Value);
                    }
                    var da = new MySqlDataAdapter(cmd);
                    var dt = new DataTable();
                    da.Fill(dt);
                    da.Dispose();                   
                    return dt;
                }                
            }
        }       
        #endregion
        #region CRUD
        private static int InsertQuery(APIConnector.GameInfo gameInfo)
        {
            //prepare the query
            string query = "INSERT INTO Game (id, name, description, image)" + " VALUES(@id, @name, @description, @image);";
            //parameters
            var args = new Dictionary<string, object>()
            {
                {"@id", gameInfo.Id}, {"@name", gameInfo.Name}, {"@description", gameInfo.Description}, {"@image",  gameInfo.BackgroundImage}
            };
            return ExecuteWrite(query, args);
        }

        //method for the researche bar
        private static APIConnector.GameInfo SelectGameByName(string name)
        {
            var query = "SELECT * FROM Game WHERE name = @name";
            var args = new Dictionary<string, object>
            {
                {"@name", name}
            };
            DataTable dt = ExecuteRead(query, args);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            var gameInfo = new APIConnector.GameInfo(gameData : dt)
            {
                Id = Convert.ToInt32(dt.Rows[0]["Id"]),
                Name = Convert.ToString(dt.Rows[0]["Name"]),
                Description = Convert.ToString(dt.Rows[0]["Description"]),
                BackgroundImage = Convert.ToString(dt.Rows[0]["Image"])
            };    
            return gameInfo;
        }

        private static APIConnector.GameInfo SelectAllQuery()
        {
            var query = "SELECT * FROM Game";
            var args = new Dictionary<string, object>()
            {
               //no parameters needed
            };
            DataTable dt = ExecuteRead(query, args);
            if (dt == null || dt.Rows.Count == 0)
            {
                Console.WriteLine("empty");
                return null;
            }
            var gameInfo = new APIConnector.GameInfo(gameData : dt)
            {
                Id = Convert.ToInt32(dt.Rows[0]["Id"]),
                Name = Convert.ToString(dt.Rows[0]["Name"]),
                Description = Convert.ToString(dt.Rows[0]["Description"]),
                BackgroundImage = Convert.ToString(dt.Rows[0]["Image"])
            };
            return gameInfo;
        }

        private static int UpdateQuery(APIConnector.GameInfo gameInfo)
        {
            //prepare the query
            //change query if needed
            string query = "UPDATE INTO Game SET xxxx = 'xxxx' WHERE id = '@id';";

            //parameter
            var args = new Dictionary<string, object>()
            {
                {"@id", gameInfo.Id }
            };
            return ExecuteWrite(query, args);
        }

        private static int DeleteQuery(APIConnector.GameInfo gameInfo)
        {
            const string query = "Delete from Game WHERE Id = @id";
            var args = new Dictionary<string, object>
            {
                {"@id", gameInfo.Id}
            };
            return ExecuteWrite(query, args);
        }
        #endregion
    }
}
