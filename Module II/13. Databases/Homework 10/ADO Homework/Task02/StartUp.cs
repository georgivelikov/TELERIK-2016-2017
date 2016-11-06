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
                SqlCommand command = new SqlCommand("SELECT c.CategoryName, c.Description FROM Categories c", connection);

                SqlDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        var name = reader["CategoryName"];
                        var description = reader["Description"];
                        Console.WriteLine("{0} : {1}", name, description);
                    }
                }
               
            }
        }
    }
}

