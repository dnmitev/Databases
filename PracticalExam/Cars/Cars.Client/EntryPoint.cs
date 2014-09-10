namespace Cars.Client
{
    using System;
    using System.IO;
    using System.Linq;

    using Cars.Data;
    using Cars.Utilities;
    using System.Data.Entity;

    internal class EntryPoint
    {
        private static void Main()
        {
            var data = new CarsData();
            var parser = new JsonParser(data);

            var pathToFile = @"../../../Data.Json.Files/data.{0}.json";
            var directoryPath = @"../../../Data.Json.Files";

            var dirInfo = new DirectoryInfo(directoryPath);

            var ctx = new CarsDbContext();

            ctx.Configuration.AutoDetectChangesEnabled = false;

            var filesCount = dirInfo.GetFiles().Count();

            for (int i = 0; i < 1; i++)
            {
                parser.ParseFiles(string.Format(pathToFile, i));
                data.SaveChanges();
            }

            ctx.Configuration.AutoDetectChangesEnabled = true;
        }
    }
}