namespace Company.Utilities.DataGenerators
{
    using Company.Data;
    using Company.Utilities.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ReportDataGenerator : DataGenerator
    {
        public ReportDataGenerator(IRandomProvider randomProvider, ILogger<string> logger, DatabaseContext database, int count)
            : base(randomProvider, logger, database, count)
        {
        }

        public override void Generate()
        {
            var employeeIds = this.Database.Employees.Select(e => e.Id).ToList();

            this.Logger.Log("\nAdding Reports...\n");

            int counter = 0;
            foreach (var employeeId in employeeIds)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    this.Database.Reports.Add(CreateItem(employeeId));
                    counter++;
                }

                if (counter % 100 == 0)
                {
                    this.Database.SaveChanges();
                    this.Logger.Log(".");
                }
            }

            this.Logger.Log("\nReports added :)");
        }

        private Report CreateItem(int employeeId)
        {
            return new Report()
            {
                EmployeeId = employeeId,
                TimeOfReport = this.RandomProvider.GetRandomDate(1950)
            };
        }
    }
}