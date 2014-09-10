namespace Company.Client
{
    using System;
    using System.Linq;

    using Company.Utilities;

    public class EntryPoint
    {
        private static void Main()
        {
            var factory = new GeneratorFactory();

            factory.Database.Configuration.AutoDetectChangesEnabled = false;

            foreach (var generator in factory.GetGenerators())
            {
                generator.Generate();
                factory.Database.SaveChanges();
            }

            factory.Database.Configuration.AutoDetectChangesEnabled = true;
        }
    }
}