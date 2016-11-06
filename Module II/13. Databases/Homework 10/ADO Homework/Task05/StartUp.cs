using System.IO;
using System.Data.SqlClient;
using System.Drawing;

namespace Task01
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string connectionString = "Server=.\\SQLEXPRESS;Database=Northwind;Integrated Security = true";
            var connection = new SqlConnection(connectionString);
            connection.Open();

            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT CategoryName, Picture FROM Categories", connection);

                SqlDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        var name = reader["CategoryName"].ToString();
                        if (name.Contains("/"))
                        {
                            name = name.Replace("/", " and ");
                        }

                        var pictureBytes = (byte[])reader["Picture"];

                        var path = string.Format("../../{0}.jpg", name);
                        
                        SavePicture(path, pictureBytes);
                    }
                }
            }
        }

        // Should work, some bytes from Categories.Picture are corrupted
        private static void SavePicture(string path, byte[] pictureBytes)
        {
            File.WriteAllBytes(path, pictureBytes);
        }
    }
}


