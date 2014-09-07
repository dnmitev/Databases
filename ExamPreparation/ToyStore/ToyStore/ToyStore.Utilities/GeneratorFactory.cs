namespace ToyStore.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ToyStore.Utilities.Contracts;
    using ToyStore.Utilities.DataGenerators;

    public class GeneratorFactory
    {
        private const int AgeRangeTotalCount = 100;
        private const int CategoriesTotalCount = 100;
        private const int ManufacturersTotalCount = 50;
        private const int ToysTotalCount = 20000;

        private readonly IRandomProvider randomProvider;
        private readonly ILogger<string> logger;
        private readonly DatabaseContext database;

        public GeneratorFactory()
            : this(RandomProvider.Instance, new ConsoleLogger(), new DatabaseContext())
        {
        }

        public GeneratorFactory(IRandomProvider randomProvider, ILogger<string> logger, DatabaseContext database)
        {
            this.randomProvider = randomProvider;
            this.logger = logger;
            this.database = database;
        }

        public DatabaseContext Database
        {
            get
            {
                return this.database;
            }
        }

        public IList<IDataGenerator> GetGenerators()
        {
            return new List<IDataGenerator>()
            {
                new AgeRangeDataGenerator(this.randomProvider,this.logger,this.database,AgeRangeTotalCount),
                new CategoryDataGenerator(this.randomProvider,this.logger,this.database,CategoriesTotalCount),
                new ManufacturerDataGenerator(this.randomProvider,this.logger,this.database,ManufacturersTotalCount),
                new ToyDataGenerator(this.randomProvider,this.logger,this.database,ToysTotalCount)
            };
        }
    }
}