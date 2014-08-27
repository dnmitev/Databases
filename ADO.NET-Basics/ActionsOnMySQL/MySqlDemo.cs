// 09. Download and install MySQL database, MySQL Connector/Net (.NET Data Provider for MySQL) + MySQL Workbench GUI administration tool. 
// Create a MySQL database to store Books (title, author, publish date and ISBN). Write methods for listing all books, finding a book by 
// name and adding a book. 

namespace ActionsOnMySQL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MySql.Data.MySqlClient;

    class MySqlDemo
    {
        static void Main()
        {
            var dbCon = new MySqlConnection(ActionsOnMySQL.Settings.Default.ConnectionString);
            dbCon.Open();

            using (dbCon)
            {
                ListAllBooks(dbCon);

                Console.Write("Search for title: ");
                string title = Console.ReadLine();

                if (title.Length < 3)
                {
                    throw new ArgumentException("Title cannot be less than 3 symbols.");
                }

                FindByBookTitle(dbCon, title);
            }
        }
 
        private static void FindByBookTitle(MySqlConnection dbCon, string title)
        {
            var command = new MySqlCommand("SELECT * FROM books WHERE Title LIKE @searched", dbCon);
            command.Parameters.AddWithValue("@searched", string.Format("%{0}%", title));

            var reader = command.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    var isbn = (string)reader["ISBN"];
                    var publishDate = (int)reader["PublishDate"];

                    string output = string.Format("Title: {0}\n\tPublished: {1}\n\tISBN: {2}", title, publishDate, isbn);
                    Console.WriteLine(output);
                }
            }
        }

        private static void ListAllBooks(MySqlConnection dbCon)
        {
            var command = new MySqlCommand("SELECT * FROM bookstore.books b	" +
                                           "INNER JOIN bookstore.authors a " +
                                           "ON  b.AuthorID = a.AuthorID", dbCon);
            var reader = command.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    var title = (string)reader["Title"];
                    var author = (string)reader["Name"];
                    var isbn = (string)reader["ISBN"];
                    var publishDate = (int)reader["PublishDate"];

                    string output = string.Format("Title: {0}\n\tAuthor: {1}\n\tPublished: {2}\n\tISBN: {3}", title, author, publishDate, isbn);
                    Console.WriteLine(output);
                }
            }
        }
    }
}