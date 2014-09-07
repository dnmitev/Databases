namespace Bookstore.Client
{
    using Bookstore.Data;
    using Bookstore.Models;
    using Bookstore.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class EntryPoint
    {
        static void Main()
        {
            // Uncomment to use the SQL EXPRESS 
            // var data = new BookstoreData("BookstoreConnectionExpress");
            var data = new BookstoreData("BookstoreConnection");

            string fileToParse = "../../../XmlFiles/complex-books.xml";
            string queriesFile = "../../../XmlFiles/reviews-queries.xml";
            string queriesResultsFile = "../../../XmlFiles/reviews-search-results.xml";

            var bookParser = new BookParser(data, fileToParse);
            bookParser.ParseFile();
        }
    }
}