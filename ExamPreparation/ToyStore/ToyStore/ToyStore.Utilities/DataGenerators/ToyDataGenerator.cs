namespace ToyStore.Utilities.DataGenerators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ToyStore.Data;
    using ToyStore.Utilities.Contracts;

    public class ToyDataGenerator : DataGenerator
    {
        private const int DefaultNullOccurancePercent = 30;

        public ToyDataGenerator(IRandomProvider randomProvider, ILogger<string> logger, DatabaseContext database, int count)
            : base(randomProvider, logger, database, count)
        {
        }

        public override void Generate()
        {
            var categoriesIds = this.Database.Categories.Select(c => c.Id).ToList();
            var manufacturersIds = this.Database.Manufacturers.Select(m => m.Id).ToList();
            var ageRangesIds = this.Database.AgeRanges.Select(ar => ar.Id).ToList();

            this.Logger.Log("\nAdding Toys....\n");
            for (int i = 0; i < this.Count; i++)
            {
                var manufacturerId = manufacturersIds[this.RandomProvider.GetRandomInt(0, manufacturersIds.Count - 1)];
                var ageRangeId = ageRangesIds[this.RandomProvider.GetRandomInt(0, ageRangesIds.Count - 1)];

                var currentToy = this.CreateItem(manufacturerId, ageRangeId);
                this.AddSubItems(currentToy, categoriesIds);

                this.Database.Toys.Add(currentToy);

                if (i % 100 == 0 && i != 0)
                {
                    this.Database.SaveChanges();
                    this.Logger.Log("@");
                }
            }

            this.Logger.Log("\nToys added :)");
        }

        private void AddSubItems(Toy currentToy, List<int> categoriesIds)
        {
            int subitemsCount = this.RandomProvider.GetRandomInt(1, 10);
            var uniqueSubItems = new HashSet<int>();

            while (uniqueSubItems.Count < subitemsCount)
            {
                uniqueSubItems.Add(categoriesIds[this.RandomProvider.GetRandomInt(0, categoriesIds.Count - 1)]);
            }

            foreach (var item in uniqueSubItems)
            {
                currentToy.Categories.Add(this.Database.Categories.Find(item));
            }
        }

        private Toy CreateItem(int manufacturerId, int ageRangeId)
        {
            return new Toy()
            {
                Name = this.RandomProvider.GetRandomString(20),
                Type = this.RandomProvider.GetRandomPercent() >= DefaultNullOccurancePercent ? this.RandomProvider.GetRandomString(15) : null,
                Color = this.RandomProvider.GetRandomPercent() >= DefaultNullOccurancePercent ? this.RandomProvider.GetRandomString(12) : null,
                Price = this.RandomProvider.GetRandomPrice(0.97, 49.97),
                ManufacturerId = manufacturerId,
                AgeRangeId = ageRangeId
            };
        }
    }
}