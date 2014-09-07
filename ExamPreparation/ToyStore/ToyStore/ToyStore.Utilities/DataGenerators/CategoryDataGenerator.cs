namespace ToyStore.Utilities.DataGenerators
{
    using System;
    using System.Linq;
    using ToyStore.Data;
    using ToyStore.Utilities.Contracts;

    public class CategoryDataGenerator : DataGenerator
    {
        public CategoryDataGenerator(IRandomProvider randomProvider, ILogger<string> logger, DatabaseContext database, int count) : base(randomProvider, logger, database, count)
        {
        }

        public override void Generate()
        {
            this.Logger.Log("\nAdding categories...\n");
            for (int i = 0; i < this.Count; i++)
            {
                this.Database.Categories.Add(this.CreateItem());

                if (i % 100 == 0 && i != 0)
                {
                    this.Database.SaveChanges();
                    this.Logger.Log(">");
                }
            }

            this.Logger.Log("\nCategories generated :)");
        }

        private Category CreateItem()
        {
            return new Category()
            {
                Name = this.RandomProvider.GetRandomLengthString()
            };
        }
    }
}