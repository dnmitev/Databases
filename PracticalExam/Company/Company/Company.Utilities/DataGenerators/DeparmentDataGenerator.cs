namespace Company.Utilities.DataGenerators
{
    using System;
    using System.Linq;

    using Company.Data;
    using Company.Utilities;
    using Company.Utilities.Contracts;

    public class DeparmentDataGenerator : DataGenerator
    {
        public DeparmentDataGenerator(IRandomProvider randomProvider, ILogger<string> logger, DatabaseContext database, int count)
            : base(randomProvider, logger, database, count)
        {
        }

        public override void Generate()
        {
            var names = this.RandomProvider.GetUniqueRandomStringsSet(this.Count, 10, 50);

            this.Logger.Log("\nAdding departments...\n");
            int counter = 0;
            foreach (var name in names)
            {
                this.Database.Departments.Add(this.CreateItem(name));
                counter++;

                if (counter % 100 == 0)
                {
                    this.Database.SaveChanges();
                    this.Logger.Log(">");
                }
            }

            this.Logger.Log("\nDepartments generated :)");
        }

        private Department CreateItem(string name)
        {
            return new Department()
            {
                Name = name
            };
        }
    }
}