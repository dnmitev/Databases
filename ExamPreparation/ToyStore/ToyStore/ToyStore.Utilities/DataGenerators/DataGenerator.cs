namespace ToyStore.Utilities.DataGenerators
{
    using System;
    using System.Linq;

    using ToyStore.Utilities.Contracts;

    public abstract class DataGenerator : IDataGenerator
    {
        public DataGenerator(IRandomProvider randomProvider, ILogger<string> logger, DatabaseContext database, int count)
        {
            this.RandomProvider = randomProvider;
            this.Logger = logger;
            this.Database = database;
            this.Count = count;
        }

        public IRandomProvider RandomProvider { get; private set; }

        public ILogger<string> Logger { get; private set; }

        public DatabaseContext Database { get; private set; }

        public int Count { get; private set; }

        public abstract void Generate();
    }
}