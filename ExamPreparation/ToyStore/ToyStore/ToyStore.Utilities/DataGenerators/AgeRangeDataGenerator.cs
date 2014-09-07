namespace ToyStore.Utilities.DataGenerators
{
    using System;
    using System.Linq;

    using ToyStore.Data;
    using ToyStore.Utilities.Contracts;

    public class AgeRangeDataGenerator : DataGenerator
    {
        public AgeRangeDataGenerator(IRandomProvider randomProvider, ILogger<string> logger, DatabaseContext database, int count)
            : base(randomProvider, logger, database, count)
        {
        }

        public override void Generate()
        {
            this.Logger.Log("\nAdding Age Ranges...\n");
            for (int i = 0; i < this.Count; i++)
            {
                this.Database.AgeRanges.Add(this.CreateItem());

                if (i % 100 == 0 && i != 0)
                {
                    this.Database.SaveChanges();
                    this.Logger.Log("*");
                }
            }

            this.Logger.Log("\nAge Ranges added :)");
        }

        private AgeRanx CreateItem()
        {
            return new AgeRanx()
            {
                MinimalAge = this.RandomProvider.GetRandomInt(0, 18),
                MaximumAge = this.RandomProvider.GetRandomInt(19, 105)
            };
        }
    }
}