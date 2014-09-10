namespace Cars.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Cars.Data.Contracts;
    using Cars.Models;

    public class CarsDbContext : DbContext, ICarsDBContext
    {
        public CarsDbContext()
            : this("CarsConnection")
        {
        }

        public CarsDbContext(string connectionstring)
            : base(connectionstring)
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookstoreDbContext, Configuration>());
            Database.SetInitializer(new DropCreateDatabaseAlways<CarsDbContext>());
        }

        public IDbSet<Car> Cars { get; set; }

        public IDbSet<City> Cities { get; set; }

        public IDbSet<Manufacturer> Manufacturers { get; set; }

        public IDbSet<Dealer> Dealers { get; set; }


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