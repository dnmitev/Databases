namespace Bookstore.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Bookstore.Data.Contracts;
    using Bookstore.Data.Migrations;
    using Bookstore.Models;

    public class BookstoreDbContext : DbContext, IBookstoreDBContext
    {
        public BookstoreDbContext()
            : this("BookstoreConnection")
        {
        }

        public BookstoreDbContext(string connectionstring)
            : base(connectionstring)
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookstoreDbContext, Configuration>());
            Database.SetInitializer(new DropCreateDatabaseAlways<BookstoreDbContext>());
        }

        public IDbSet<Book> Books { get; set; }

        public IDbSet<Author> Authors { get; set; }

        public IDbSet<Review> Reviews { get; set; }

        public IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}