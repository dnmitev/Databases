namespace Cars.Data.Contracts
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    using Cars.Models;

    public interface ICarsDBContext
    {
        IDbSet<Car> Cars { get; set; }

        IDbSet<City> Cities { get; set; }

        IDbSet<Manufacturer> Manufacturers { get; set; }

        IDbSet<Dealer> Dealers { get; set; }


        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        void SaveChanges();
    }
}