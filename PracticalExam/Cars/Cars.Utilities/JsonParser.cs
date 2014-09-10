namespace Cars.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    using Cars.Data;
    using Cars.Models;
    using Newtonsoft.Json;

    public class JsonParser
    {
        public JsonParser(CarsData data)
        {
            this.Database = data;
        }

        public CarsData Database { get; private set; }

        public void ParseFiles(string pathToFile)
        {
            // get the unicode read json file
            var json = new StreamReader(pathToFile, Encoding.UTF8).ReadToEnd();

            // deserialize it to .NET object
            var obj = JsonConvert.DeserializeObject(json);

            // get collection of all data
            List<CustomCarObject> list = JsonConvert.DeserializeObject<List<CustomCarObject>>(json);

            int counter = 0;

            foreach (var item in list)
            {
                var city = this.GetCity(item);
                var dealer = this.GetDealer(item);

                this.AddCity(city, dealer);

                var manufacturer = this.GetManufacturer(item);

                Car car = this.GetCarWithUniqueManufacturer(manufacturer, item, dealer);

                this.Database.Cars.Add(car);
                counter++;

                // I know it is slow but I have no time to improve
                this.Database.SaveChanges();

                //if (counter % 100 == 0)
                //{
                //    this.Database.SaveChanges();
                //    Console.Write("*");
                //}
            }
        }

        private Car GetCarWithUniqueManufacturer(Manufacturer manufacturer, CustomCarObject item, Dealer dealer)
        {
            var doesManufacturerExists = this.Database.Manufacturers.All()
                                             .Any(m => m.Name == manufacturer.Name);
            Car car;
            if (!doesManufacturerExists)
            {
                car = this.GetCar(manufacturer, item, dealer);
            }
            else
            {
                var existingManufacturer = this.Database.Manufacturers.All()
                                               .FirstOrDefault(m => m.Name == manufacturer.Name);

                car = this.GetCar(existingManufacturer, item, dealer);
            }

            return car;
        }

        private void AddCity(City city, Dealer dealer)
        {
            var doesCityExists = this.Database.Cities.All()
                                     .Any(c => c.Name == city.Name);

            if (!doesCityExists)
            {
                // adds non-existing city
                dealer.Cities.Add(city);
            }
            else
            {
                var currentCity = this.Database.Cities.All()
                                      .FirstOrDefault(c => c.Name == city.Name);

                // adds an already existing city
                dealer.Cities.Add(currentCity);
            }
        }

        private Car GetCar(Manufacturer manufacturer, CustomCarObject item, Dealer dealer)
        {
            return new Car()
            {
                Manufacturer = manufacturer,
                Model = item.Model,
                Price = item.Price,
                TransmissionType = (TransmissionType)item.TransmissionType,
                Year = item.Year,
                Dealer = dealer
            };
        }

        private Manufacturer GetManufacturer(CustomCarObject item)
        {
            return new Manufacturer()
            {
                Name = item.ManufacturerName
            };
        }

        private Dealer GetDealer(CustomCarObject item)
        {
            return new Dealer()
            {
                Name = item.Dealer.Name
            };
        }

        private City GetCity(CustomCarObject item)
        {
            return new City()
            {
                Name = item.Dealer.City
            };
        }
    }
}