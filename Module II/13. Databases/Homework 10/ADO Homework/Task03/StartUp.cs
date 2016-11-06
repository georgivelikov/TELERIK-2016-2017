using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Task01
{
    public class StartUp
    {
        public static void Main()
        {
            Dictionary<string, List<string>> holder = new Dictionary<string, List<string>>();

            string connectionString = "Server=.\\SQLEXPRESS;Database=Northwind;Integrated Security = true";
            var connection = new SqlConnection(connectionString);
            connection.Open();

            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT p.ProductName, c.CategoryName FROM Products p " +
                                                        "JOIN Categories c ON c.CategoryID = p.CategoryID", connection);

                SqlDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        var productName = reader["ProductName"].ToString();
                        var categoryName = reader["CategoryName"].ToString();
                        
                        if (!holder.ContainsKey(categoryName))
                        {
                            holder.Add(categoryName, new List<string>());
                        }

                        holder[categoryName].Add(productName);
                    }
                }

                foreach (var item in holder)
                {
                    Console.WriteLine("{0}: {1}", item.Key, string.Join(", ", item.Value));
                    Console.WriteLine();
                }
            }
        }
    }
}