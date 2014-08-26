namespace ActionsOnNorthwind
{
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;

    internal class NorthwindDemo
    {
        private const int OLE_METAFILEPICT_START_POSITION = 78;

        private static void Main()
        {
            var dbCon = new SqlConnection(ActionsOnNorthwind.DBConnectionSettings.Default.ConnectionString);
            dbCon.Open();

            using (dbCon)
            {
                // 01. Write a program that retrieves from the Northwind sample database in 
                // MS SQL Server the number of rows in the Categories table.
                var sqlCountOfCategories = new SqlCommand("SELECT COUNT(*) FROM Categories", dbCon);
                var categoriesTotalCount = (int)sqlCountOfCategories.ExecuteScalar();
                Console.WriteLine("Total count of the 'Categories' is {0}", categoriesTotalCount);
                PrintSeparator();

                // 02. Write a program that retrieves the name and description of all categories in the Northwind DB. 
                var sqlRetrieveCategoriesData = new SqlCommand("SELECT CategoryName, Description FROM Categories", dbCon);
                var categoriesReader = sqlRetrieveCategoriesData.ExecuteReader();

                using (categoriesReader)
                {
                    while (categoriesReader.Read())
                    {
                        var name = (string)categoriesReader["CategoryName"];
                        var description = (string)categoriesReader["Description"];
                        Console.WriteLine("CategoryName: {0}; Description: {1}", name, description);
                    }

                    PrintSeparator();
                }

                // 03. Write a program that retrieves from the Northwind database all product categories and the names of the 
                // products in each category. Can you do this with a single SQL query (with table join)?
                string retrieveCategorAndProductString = "SELECT p.ProductName, c.CategoryName FROM Categories c INNER JOIN Products p ON c.CategoryID=p.CategoryID";

                var sqlRetrieveCategoriesAndProductName = new SqlCommand(retrieveCategorAndProductString, dbCon);
                var prductsAndCategoriesReader = sqlRetrieveCategoriesAndProductName.ExecuteReader();

                using (prductsAndCategoriesReader)
                {
                    while (prductsAndCategoriesReader.Read())
                    {
                        var productName = (string)prductsAndCategoriesReader["ProductName"];
                        var categoryName = (string)prductsAndCategoriesReader["CategoryName"];
                        Console.WriteLine("ProductName: {0}; CategoryName: {1}", productName, categoryName);
                    }

                    PrintSeparator();
                }

                // 04. Write a method that adds a new product in the products table in the Northwind database. 
                // Use a parameterized SQL command.
                string insertProductString = "INSERT INTO Products(ProductName, Discontinued) VALUES (@productName, @discontinued)";
                var sqlInsertQuery = new SqlCommand(insertProductString, dbCon);
                sqlInsertQuery.Parameters.AddWithValue("@productName", "Nahuinik");
                sqlInsertQuery.Parameters.AddWithValue("@discontinued", true);
                sqlInsertQuery.ExecuteNonQuery();

                // 05. Write a program that retrieves the images for all categories in the Northwind database and stores 
                // them as JPG files in the file system. 
                // solution source: http://tihomir.me/tag/northwind
                var sqlGetPictures = new SqlCommand("SELECT CategoryName, Picture FROM Categories", dbCon);
                var picturesReader = sqlGetPictures.ExecuteReader();

                using (picturesReader)
                {
                    while (picturesReader.Read())
                    {
                        string categoryName = ((string)picturesReader["CategoryName"]);
                        if (categoryName.Contains('/') == true)
                        {
                            categoryName = categoryName.Replace('/', ' ');
                        }
                        byte[] pictureBytes = picturesReader["Picture"] as byte[];

                        MemoryStream stream = new MemoryStream(
                            pictureBytes, OLE_METAFILEPICT_START_POSITION,
                            pictureBytes.Length - OLE_METAFILEPICT_START_POSITION);

                        Image image = Image.FromStream(stream);
                        using (image)
                        {
                            image.Save(string.Format("{0}.jpg", categoryName), ImageFormat.Jpeg);
                        }
                    }
                }
            }
        }

        private static void PrintSeparator()
        {
            Console.WriteLine(new string('-', 60));
        }
    }
}