using GameLogs.apiDataCollection;
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
            using (var con = new MySqlConnection(connString)
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
    }

        static private List<string> ExecuteQuerySelect()
        {
            List<string> queryResults = new List<string>();

            //TODO Improvement - use an external file to store sensitive data
            

            //prepare the connection
            MySqlConnection connection = new MySqlConnection(connString);
            connection.Open();

            //prepare the query
            string query = "SELECT name, releaseDate, image, description, gameState FROM Game;";

            //set and execute the query 
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
           
            //retrieve values
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //TODO Improvement - how to extract multiple fields ?
                //TODO Improvement - how deal with numeric values ?
                queryResults.Add(reader.GetString(0) + " - " + reader.GetString(1));
            }
            return queryResults;
        }

         static private void InsertQuery(ApiData apiData)
         {
            string Json = "C:\\Users\\pb34nwq\\source\\repos\\GameLogs\\docs\\fortnite.json";

            //prepare the query
            var dataSet = JsonConvert.DeserializeObject<ApiData>( Json );
            //TODO add value parameters
            string insertQuery = "INSERT INTO Game (id, name, description, image, gameState)" + " VALUES(@id, @name, @description, @image, @gameState );";

            //parameters
            //TODO figure out how to implement the bool gameState
            var args = new Dictionary<string, object>() 
            {
                {"@id", apiData.id}, {"@name", apiData.name}, {"@description", apiData.description}, {"@image", apiData.image}
            };

            //set and execute the query 
            MySqlCommand cmd = new MySqlCommand(insertQuery, connection);
            cmd.ExecuteNonQuery();
         }

        //add in method parameter the data value of the form
        static private void UpdateQuery(ApiData apiData)
        {
            string connString = "server=localhost;user=DBGameLogs;database=mydb;port=3306;password=Pa$$W0rd;";

            //prepare the connection
            MySqlConnection connection = new MySqlConnection(connString);
            connection.Open();

            //prepare the query
            //TODO switch case statement for when we want to update the state of the game (todo or finished)
            //TODO add value parameters
            const string updateQuery = "UPDATE INTO Game SET gameState = 'False' WHERE id = '@id';";

            //parameter
            var args = new Dictionary<string, object>()
            {
                {"@id", apiData.id }
            };

            //set and execute the query 
            MySqlCommand cmd = new MySqlCommand(updateQuery, connection);
            cmd.ExecuteNonQuery();
        }
    } 
}