using System;
using System.Data.SqlClient;

namespace Task01
{
    public class StartUp
    {
        public static void Main()
        {
            var pattern = Console.ReadLine();
            //var pattern = "Li";

            string connectionString = "Server=.\\SQLEXPRESS;Database=Northwind;Integrated Security = true";
            var connection = new SqlConnection(connectionString);
            connection.Open();

            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT p.ProductName FROM Products p WHERE CHARINDEX(@pattern, p.ProductName) > 0", connection);
                command.Parameters.AddWithValue("@pattern", pattern);

                SqlDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    Console.WriteLine("Products with {0} in their name:", pattern);
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["ProductName"]);
                    }
                }
            }
        }
    }
}

