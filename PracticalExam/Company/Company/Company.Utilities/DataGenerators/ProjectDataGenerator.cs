namespace Company.Utilities.DataGenerators
{
    using System;
    using System.Linq;

    using Company.Data;
    using Company.Utilities;
    using Company.Utilities.Contracts;

    public class ProjectDataGenerator : DataGenerator
    {
        public ProjectDataGenerator(IRandomProvider randomProvider, ILogger<string> logger, DatabaseContext database, int count)
            : base(randomProvider, logger, database, count)
        {
        }

        public override void Generate()
        {
            this.Logger.Log("\nAdding projects...\n");
            for (int i = 0; i < this.Count; i++)
            {
                this.Database.Projects.Add(this.CreateItem());

                if (i % 100 == 0 && i!=0)
                {
                    this.Database.SaveChanges();
                    this.Logger.Log("->");
                }
            }

            this.Logger.Log("\nProjects added :)");
        }

        private Project CreateItem()
        {
            return new Project()
            {
                Name = this.RandomProvider.GetRandomLengthString(5, 50)
            };
        }
    }
}