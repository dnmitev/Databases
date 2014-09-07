namespace Bookstore.Data.Contracts
{
    using System;
    using System.Linq;

    using Bookstore.Models;

    public interface IBookstoreData
    {
        IGenericRepository<Book> Books { get; }

        IGenericRepository<Author> Authors { get; }

        IGenericRepository<Review> Reviews { get; }
    }
}