namespace ToyStore.Client
{
    using System;
    using System.Linq;

    using ToyStore.Utilities;

    public class EntryPoint
    {
        private static void Main()
        {
            try
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
            catch 
            {
                Console.WriteLine("Used SQL Server for the task");
                Console.WriteLine("Please be kind and the change the CONNECTION STRING in the app.config files.");
            }
           
        }
    }
}