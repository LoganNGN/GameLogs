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
        //The collection of results
        static List<string> displayGames = new List<string>();

        internal static void ConnectionToDB()
        {
            displayGames = ExecuteQuerySelect();
            InsertQuery();
            UpdateQuery();
            
        }

        static private List<string> ExecuteQuerySelect()
        {
            List<string> queryResults = new List<string>();

            //TODO Improvement - use an external file to store sensitive data
            string connString = "server=localhost;user=DBGameLogs;database=mydb;port=3306;password=Pa$$W0rd;";

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

            string connString = "server=localhost;user=DBGameLogs;database=mydb;port=3306;password=Pa$$W0rd;";

            //prepare the connection
            MySqlConnection connection = new MySqlConnection(connString);
            connection.Open();

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