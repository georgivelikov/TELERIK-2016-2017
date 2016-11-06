using System;
using System.Data.OleDb;

namespace Task01
{
    using System.Collections.Generic;
    using System.Data;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            string path = @"../../DataFile.xlsx";
            string connectionString = GetConnectionString(path);

            var connection = new OleDbConnection(connectionString);
            connection.Open();
            using (connection)
            {
                var table = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                var header = table.Rows[0]["TABLE_NAME"].ToString();

                ReadFromFile(connection, header);
                WriteToFile(connection, header, 5, "Stamat", 7);
                Console.WriteLine("After an adding-----------------------------");
                ReadFromFile(connection, header);
            }
        }

        private static string GetConnectionString(string path)
        {
            Dictionary<string, string> props = new Dictionary<string, string>();

            // XLSX - Excel 2007, 2010, 2012, 2013
            props["Provider"] = "Microsoft.ACE.OLEDB.12.0";
            props["Extended Properties"] = "Excel 12.0 XML";
            props["Data Source"] = path;

            // XLS - Excel 2003 and Older
            //props["Provider"] = "Microsoft.Jet.OLEDB.4.0";
            //props["Extended Properties"] = "Excel 8.0";
            //props["Data Source"] = "C:\\MyExcel.xls";

            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<string, string> prop in props)
            {
                sb.Append(prop.Key);
                sb.Append('=');
                sb.Append(prop.Value);
                sb.Append(';');
            }

            return sb.ToString();
        }

        private static void ReadFromFile(OleDbConnection connection, string header)
        {
            var command = new OleDbCommand(@"SELECT * FROM [" + header + "]", connection);
            var adapter = new OleDbDataAdapter(command);

            using (adapter)
            {
                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                var reader = dataSet.CreateDataReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        var currentName = reader["Name"];
                        var currentScore = reader["Score"];
                        Console.WriteLine("{0}: {1}", currentName, currentScore);
                    }
                }
            }
        }

        private static void WriteToFile(OleDbConnection conection, string header, int id, string name, int score)
        {
            var command = new OleDbCommand(@"INSERT INTO [" + header + @"] VALUES (@id, @name, @score)", conection);

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@score", score);

            command.ExecuteNonQuery();
        }

        // http://www.codeproject.com/Tips/705470/Read-and-Write-Excel-Documents-Using-OLEDB
        //private static void WriteExcelFile(string connectionString)
        //{
        //    using (OleDbConnection conn = new OleDbConnection(connectionString))
        //    {
        //        conn.Open();
        //        OleDbCommand cmd = new OleDbCommand();
        //        cmd.Connection = conn;

        //        cmd.CommandText = "CREATE TABLE [table1] (id INT, name VARCHAR, datecol DATE );";
        //        cmd.ExecuteNonQuery();

        //        cmd.CommandText = "INSERT INTO [table1](id,name,datecol) VALUES(1,'AAAA','2014-01-01');";
        //        cmd.ExecuteNonQuery();

        //        cmd.CommandText = "INSERT INTO [table1](id,name,datecol) VALUES(2, 'BBBB','2014-01-03');";
        //        cmd.ExecuteNonQuery();

        //        cmd.CommandText = "INSERT INTO [table1](id,name,datecol) VALUES(3, 'CCCC','2014-01-03');";
        //        cmd.ExecuteNonQuery();

        //        cmd.CommandText = "UPDATE [table1] SET name = 'DDDD' WHERE id = 3;";
        //        cmd.ExecuteNonQuery();

        //        conn.Close();
        //    }
        //}

        //private static DataSet ReadExcelFile(string connectionString)
        //{
        //    DataSet ds = new DataSet();

        //    using (OleDbConnection conn = new OleDbConnection(connectionString))
        //    {
        //        conn.Open();
        //        OleDbCommand cmd = new OleDbCommand();
        //        cmd.Connection = conn;

        //        // Get all Sheets in Excel File
        //        DataTable dtSheet = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

        //        // Loop through all Sheets to get data
        //        foreach (DataRow dr in dtSheet.Rows)
        //        {
        //            string sheetName = dr["TABLE_NAME"].ToString();

        //            if (!sheetName.EndsWith("$"))
        //                continue;

        //            // Get all rows from the Sheet
        //            cmd.CommandText = "SELECT * FROM [" + sheetName + "]";

        //            DataTable dt = new DataTable();
        //            dt.TableName = sheetName;

        //            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        //            da.Fill(dt);

        //            ds.Tables.Add(dt);
        //        }

        //        cmd = null;
        //        conn.Close();
        //    }

        //    return ds;
        //}
    }
}

