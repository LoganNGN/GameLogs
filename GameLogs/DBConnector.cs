using MySql.Data.MySqlClient;
// TODO update file for our need
namespace PrototypeDbConnector
{
    internal class Program
    {
        //The collection of results
        static List<string> users = new List<string>();

        static void Maine(string[] args)
        {
            users = ExecuteQuerySelect();

            foreach (string customer in users)
            {
                Console.WriteLine(customer);
            }
        }

        static private List<string> ExecuteQuerySelect()
        {
            List<string> queryResults = new List<string>();

            //TODO Improvement - use an external file to store sensitive data
            string connString = "server=localhost;user=demoProjetPoo;database=classicmodels;port=3306;password=K5BoyoGA8uCu;";

            //prepare the connection
            MySqlConnection connection = new MySqlConnection(connString);
            connection.Open();

            //prepare the query
            //TODO Improvement - Using @parameter and value to build the query
            //TODO Improvement - https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlparametercollection.addwithvalue?view=dotnet-plat-ext-7.0
            string query = "SELECT customerNumber, customerName FROM customers WHERE customerNumber < 150;";

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
    }
}