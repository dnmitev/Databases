namespace Cars.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Cars.Data.Contracts;
    using Cars.Data.Repositories;
    using Cars.Models;

    public class CarsData
    {
        private readonly ICarsDBContext context;
        private readonly IDictionary<Type, object> repositories;

        public CarsData()
            : this(new CarsDbContext())
        {
        }

        public CarsData(string connectionString)
            : this(new CarsDbContext(connectionString))
        {
        }

        public CarsData(ICarsDBContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<Car> Cars
        {
            get
            {
                return this.GetRepository<Car>();
            }
        }

        public IGenericRepository<City> Cities
        {
            get
            {
                return this.GetRepository<City>();
            }
        }

        public IGenericRepository<Manufacturer> Manufacturers
        {
            get
            {
                return this.GetRepository<Manufacturer>();
            }
        }

        public IGenericRepository<Dealer> Dealers
        {
            get
            {
                return this.GetRepository<Dealer>();
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