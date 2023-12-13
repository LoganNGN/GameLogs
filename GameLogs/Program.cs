using System.Data;
using GameLogs.apiDataCollection;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;

namespace GameLogs
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>

        private static ApiData apiData = new ApiData();

        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
            SelectAllQuery();
            InsertQuery(apiData);
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
        private static int InsertQuery(ApiData apiData)
        {
            //TODO when sven finishes the json deserialiser and gives me the files, insert the path to the file for the query

            //prepare the query
            string query = "INSERT INTO Game (id, name, description, image)" + " VALUES(@id, @name, @description, @image);";
            //parameters
            var args = new Dictionary<string, object>()
            {
                {"@id", apiData.Id}, {"@name", apiData.Name}, {"@description", apiData.Description}, {"@image", apiData.Image}
            };
            return ExecuteWrite(query, args);
        }

        //method for the researche bar
        private static ApiData SelectGameByName(string name)
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
            var apiData = new ApiData
            {
                Id = Convert.ToInt32(dt.Rows[0]["Id"]),
                Name = Convert.ToString(dt.Rows[0]["Name"]),
                Description = Convert.ToString(dt.Rows[0]["Description"]),
                Image = Convert.ToString(dt.Rows[0]["Image"])
            };    
            return apiData;
        }

        private static ApiData SelectAllQuery()
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
            var apiData = new ApiData
            {
                Id = Convert.ToInt32(dt.Rows[0]["Id"]),
                Name = Convert.ToString(dt.Rows[0]["Name"]),
                Description = Convert.ToString(dt.Rows[0]["Description"]),
                Image = Convert.ToString(dt.Rows[0]["Image"])
            };
            return apiData;
        }

        private static int UpdateQuery(ApiData apiData)
        {
            //prepare the query
            //change query if needed
            string query = "UPDATE INTO Game SET xxxx = 'xxxx' WHERE id = '@id';";

            //parameter
            var args = new Dictionary<string, object>()
            {
                {"@id", apiData.Id }
            };
            return ExecuteWrite(query, args);
        }

        private static int DeleteQuery(ApiData apiData)
        {
            const string query = "Delete from Game WHERE Id = @id";
            var args = new Dictionary<string, object>
            {
                {"@id", apiData.Id}
            };
            return ExecuteWrite(query, args);
        }
        #endregion
    }
}