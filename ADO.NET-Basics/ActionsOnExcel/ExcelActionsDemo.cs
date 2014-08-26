namespace ActionsOnExcel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data;
    using System.Data.OleDb;
    using System.Data.SqlClient;

    class ExcelActionsDemo
    {
        static void Main()
        {
            var connection = new OleDbConnection(ActionsOnExcel.Settings.Default.ConnectionString);
            connection.Open();
            using (connection)
            {

                // 06. Create an Excel file with 2 columns: name and score. Write a program that reads your MS Excel file 
                // through the OLE DB data provider and displays the name and score row by row. 
                var oleDbSelectAllData = new OleDbCommand("SELECT * FROM [Exam$]", connection);
                var reader = oleDbSelectAllData.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        var name = (string)reader["Name"];
                        var score = (double)reader["Score"];

                        Console.WriteLine("{0} -> Score: {1}", name, score); ;
                    }
                }

                // 07. Implement appending new rows to the Excel file. 
                var oleDbInsertData = new OleDbCommand("INSERT INTO [Exam$](Name, Score) VALUES (@name, @score)", connection);

                oleDbInsertData.Parameters.AddWithValue("@name", "Dinko");
                oleDbInsertData.Parameters.AddWithValue("@score", 55);

                oleDbInsertData.ExecuteNonQuery();
            }
        }
    }
}