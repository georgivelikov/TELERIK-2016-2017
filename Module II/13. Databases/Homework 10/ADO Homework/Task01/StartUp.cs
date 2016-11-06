using System;
using System.Data.SqlClient;

namespace Task01
{
    public class StartUp
    {
        public static void Main()
        {
            string connectionString = "Server=.\\SQLEXPRESS;Database=Northwind;Integrated Security = true";
            var connection = new SqlConnection(connectionString);
            connection.Open();

            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT  COUNT(*) FROM Categories", connection);

                var numberOfRows = (int)command.ExecuteScalar();
                Console.WriteLine("Number of rows: " + numberOfRows);
            }
        }
    }
}
