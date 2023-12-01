﻿using GameLogs.apiDataCollection;
using Newtonsoft.Json;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing.Text;
using System.Reflection;

namespace GameLogs.DbConnector
{
    internal class Program
    {
        private int ExecuteWrite(string query, Dictionary<string, object> args)
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

        private int InsertQuery(ApiData apiData)
        {
            //TODO make the json a txt file
            string Json = "C:\\Users\\pb34nwq\\source\\repos\\GameLogs\\docs\\fortnite.json";

            //prepare the query
            var dataSet = JsonConvert.DeserializeObject<ApiData>(Json);
            //TODO add value parameters
            string query = "INSERT INTO Game (id, name, description, image, gameState)" + " VALUES(@id, @name, @description, @image, @gameState );";

            //parameters
            //TODO figure out how to implement the bool gameState
            var args = new Dictionary<string, object>()
            {
                {"@id", apiData.id}, {"@name", apiData.name}, {"@description", apiData.description}, {"@image", apiData.image}
            };

            return ExecuteWrite(query, args);
        }

        //add in method parameter the data value of the form
        private int UpdateQuery(ApiData apiData)
        {
            //prepare the query
            //TODO switch case statement for when we want to update the state of the game (todo or finished)
            //TODO add value parameters
            string query = "UPDATE INTO Game SET gameState = 'False' WHERE id = '@id';";

            //parameter
            var args = new Dictionary<string, object>()
            {
                {"@id", apiData.id }
            };
            return ExecuteWrite(query, args);
        }
    }  
}