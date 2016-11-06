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
                SqlCommand command = new SqlCommand(
                    "INSERT INTO Products VALUES (@productName, @supplierId, @categoryId, @quantityPerUnit, @unitPrice, @unitInStock, @unitsOnOrder, @reorderLever, @discontinued)", 
                    connection);
                //insert into Products values ('Marijuana', 3, 3, 25, 10, 50, 2, 0, 'false')
                command.Parameters.AddWithValue("@productName", "JackDaniels");
                command.Parameters.AddWithValue("@supplierId", 3);
                command.Parameters.AddWithValue("@categoryId", 3);
                command.Parameters.AddWithValue("@quantityPerUnit", 25);
                command.Parameters.AddWithValue("@unitPrice", 10);
                command.Parameters.AddWithValue("@unitInStock", 50);
                command.Parameters.AddWithValue("@unitsOnOrder", 2);
                command.Parameters.AddWithValue("@reorderLever", 0);
                command.Parameters.AddWithValue("@discontinued", "false");

                command.ExecuteNonQuery();
            }
        }
    }
}


