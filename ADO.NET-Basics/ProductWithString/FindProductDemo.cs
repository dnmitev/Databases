// 08. Write a program that reads a string from the console and finds all products that contain this string. Ensure you handle correctly 
// characters like ', %, ", \ and _. 
namespace ProductWithString
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;

    internal class FindProductDemo
    {
        private static void Main()
        {
            string input = GetInputData();

            GetSearchedDataFromDB(input);
        }
 
        private static void GetSearchedDataFromDB(string searchedString)
        {
            var dbCon = new SqlConnection(ProductWithString.Settings.Default.ConnectionString);
            dbCon.Open();

            using (dbCon)
            {
                var command = new SqlCommand("SELECT ProductName FROM Products WHERE ProductName LIKE @searchedString", dbCon);
                command.Parameters.AddWithValue("@searchedString", string.Format("%{0}%", searchedString));

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string product = (string)reader["ProductName"];
                    Console.WriteLine(product);
                }
            }
        }

        private static string GetInputData()
        {
            Console.Write("Search for: ");
            string input = Console.ReadLine();

            if (input.Length < 3)
            {
                throw new ArgumentException("Searched string is too short");
            }

            return input;
        }
    }
}