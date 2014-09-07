namespace Bookstore.Client
{
    using Bookstore.Data;
    using Bookstore.Models;
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

            data.Books.Add(new Book()
            {
                Title = "ala bala",
            });

            data.SaveChanges();
        }
    }
}