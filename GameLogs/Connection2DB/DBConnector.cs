using GameLogs.apiDataCollection;
using Newtonsoft.Json;
using System.Data;
using MySql.Data.MySqlClient;
// TODO update file for our need
namespace PrototypeDbConnector
{
    internal class Program
    {
        //The collection of results
        static List<string> writeGame = new List<string>();
        static List<string> displayGames = new List<string>();

        static void ConnectionToDB(string[] args)
        {
            displayGames = ExecuteQuerySelect();

            foreach (string game in writeGame)
            {
                Console.WriteLine(writeGame);
            }
        }

        static private List<string> ExecuteQuerySelect()
        {
            List<string> queryResults = new List<string>();

            //TODO Improvement - use an external file to store sensitive data
            string connString = "server=localhost;user=DBGameLogs;database=classicmodels;port=3306;password=Pa$$W0rd;";

            //prepare the connection
            MySqlConnection connection = new MySqlConnection(connString);
            connection.Open();

            //prepare the query
            //TODO Improvement - Using @parameter and value to build the query
            //TODO Improvement - https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlparametercollection.addwithvalue?view=dotnet-plat-ext-7.0
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
        
        //method to Update Database
        public DataTable GetGame(string query)
        {
            throw new NotImplementedException();
        }

        private List<string> InsertQuery(ApiData apiData)
        {
            List<string> queryResults = new List<string>();

            string connString = "server=localhost;user=DBGameLogs;database=classicmodels;port=3306;password=Pa$$W0rd;";

            //prepare the connection
            MySqlConnection connection = new MySqlConnection(connString);
            connection.Open();

            //prepare the query
            //todo add the json file name
            var root = JsonConvert.DeserializeObject<ApiData>( json );
            //TODO add value parameters
            string insertQuery = "INSERT INTO Game (id, name, description, image, gameState)" + " VALUES(@id, @name, @description, @image, @gameState );";

            //set and execute the query 
            MySqlCommand cmd = new MySqlCommand(insertQuery, connection);
            cmd.ExecuteNonQuery();
            
            return queryResults;
        }

        //add in method parameter the data value of the form
        private List<string> UpdateQuery()
        {
            List<string> queryResults = new List<string>();

            string connString = "server=localhost;user=DBGameLogs;database=classicmodels;port=3306;password=Pa$$W0rd;";

            //prepare the connection
            MySqlConnection connection = new MySqlConnection(connString);
            connection.Open();

            //prepare the query
            //TODO switch case statement for when we want to update the state of the game (todo or finished)
            //TODO add value parameters
            string updateQuery = "UPDATE INTO Game SET gameState = '@gameState' WHERE id = '@id';";

            //set and execute the query 
            MySqlCommand cmd = new MySqlCommand(updateQuery, connection);
            cmd.ExecuteNonQuery();

            return queryResults;
        }
    } 
}