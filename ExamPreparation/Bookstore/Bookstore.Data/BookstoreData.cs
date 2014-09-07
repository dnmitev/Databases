namespace Bookstore.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Bookstore.Data.Contracts;
    using Bookstore.Data.Repositories;
    using Bookstore.Models;

    public class BookstoreData
    {
        private readonly IBookstoreDBContext context;
        private readonly IDictionary<Type, object> repositories;

        public BookstoreData()
            : this(new BookstoreDbContext())
        {
        }

        public BookstoreData(string connectionString)
            : this(new BookstoreDbContext(connectionString))
        {
        }

        public BookstoreData(IBookstoreDBContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<Book> Books
        {
            get
            {
                return this.GetRepository<Book>();
            }
        }

        public IGenericRepository<Author> Authors
        {
            get
            {
                return this.GetRepository<Author>();
            }
        }

        public IGenericRepository<Review> Reviews
        {
            get
            {
                return this.GetRepository<Review>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(GenericRepository<T>);
                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}