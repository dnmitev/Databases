namespace ToyStore.Utilities.DataGenerators
{
    using System;
    using System.Linq;

    using ToyStore.Data;
    using ToyStore.Utilities.Contracts;

    public class ManufacturerDataGenerator : DataGenerator
    {
        public ManufacturerDataGenerator(IRandomProvider randomProvider, ILogger<string> logger, DatabaseContext database, int count)
            : base(randomProvider, logger, database, count)
        {
        }

        public override void Generate()
        {
            var generatedNames = this.RandomProvider.GetUniqueRandomStringsSet(this.Count);

            int counter = 0;
            this.Logger.Log("\nAdding manufacturers...\n");
            foreach (var name in generatedNames)
            {
                this.Database.Manufacturers.Add(this.CreateItem(name));
                counter++;

                if (counter % 100 == 0)
                {
                    this.Database.SaveChanges();
                    this.Logger.Log("->");
                }
            }

            this.Logger.Log("\nManufacturers added :)");
        }

        private Manufacturer CreateItem(string name)
        {
            return new Manufacturer()
            {
                Name = name,
                Country = this.RandomProvider.GetRandomString(5)
            };
        }
    }
}