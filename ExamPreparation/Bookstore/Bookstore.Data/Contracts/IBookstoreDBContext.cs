namespace Bookstore.Data.Contracts
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    using Bookstore.Models;

    public interface IBookstoreDBContext
    {
        IDbSet<Book> Books { get; set; }

        IDbSet<Author> Authors { get; set; }

        IDbSet<Review> Reviews { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        void SaveChanges();
    }
}