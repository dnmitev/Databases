namespace Company.Utilities.DataGenerators
{
    using Company.Utilities.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    public class ManagerGenerator : DataGenerator
    {
        private const double Factor = 0.95;

        public ManagerGenerator(IRandomProvider randomProvider, ILogger<string> logger, DatabaseContext database, int count)
            : base(randomProvider, logger, database, count)
        {
        }

        public override void Generate()
        {
            var totalCount = (int)Factor * this.Count;
            var employees = this.Database.Employees;

            this.Logger.Log("\nAdding Managers...");
            foreach (var employee in employees)
            {
                employee.ManagerId = this.RandomProvider.GetRandomInt(1, totalCount);
            }

            this.Logger.Log("\nManagers added :)");
        }
    }
}