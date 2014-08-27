namespace ActionsOnSQLite
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.SQLite;

    class SqLiteDemo
    {
        static void Main()
        {
            var dbCon = new SQLiteConnection(ActionsOnSQLite.Settings.Default.ConnectionString);
            dbCon.Open();

            CreateData(dbCon, "Fools Die", "Mario Puzo", "1230123-123123-123", new DateTime(1980, 10, 10));
            CreateData(dbCon, "The Lost World", "sir Arthur Connan Doyle", "1230123-1254623-123", new DateTime(1898, 10, 26));

            var command = new SQLiteCommand("SELECT * FROM books", dbCon);
            var reader = command.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    var title = (string)reader["Name"];
                    var author = (string)reader["Author"];
                    var isbn = (string)reader["ISBN"];
                    var date = (DateTime)reader["Date"];
                    Console.WriteLine("Title: {0}; Author: {1} ; Publish Date: {2} , ISBN: {3}", title, author, date, isbn);
                }
            }
        }

        private static void CreateData(SQLiteConnection connection, string name, string author, string isbn, DateTime date)
        {
            var query = "INSERT INTO books (Name , Author , ISBN , Date) VALUES (@name , @author , @isbn , @date)";
            SQLiteCommand insertCommand = new SQLiteCommand(query, connection);
            insertCommand.Parameters.AddWithValue("@name", name);
            insertCommand.Parameters.AddWithValue("@author", author);
            insertCommand.Parameters.AddWithValue("@isbn", isbn);
            insertCommand.Parameters.AddWithValue("@date", date);
            insertCommand.ExecuteNonQuery();
        }
    }
}