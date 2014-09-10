namespace Cars.Data.Contracts
{
    using System;
    using System.Linq;

    using Cars.Models;

    public interface ICarsData
    {
        IGenericRepository<Car> Cars { get; }

        IGenericRepository<Manufacturer> Manufacturers { get; }

        IGenericRepository<Dealer> Dealers { get; }

        IGenericRepository<City> Cities { get; }
    }
}