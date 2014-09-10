namespace Company.Utilities.DataGenerators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Company.Data;
    using Company.Utilities;
    using Company.Utilities.Contracts;

    public class EmployessProjectsDataGenerator : DataGenerator
    {
        public EmployessProjectsDataGenerator(IRandomProvider randomProvider, ILogger<string> logger, DatabaseContext database, int count)
            : base(randomProvider, logger, database, count)
        {
        }

        public override void Generate()
        {
            var projectIds = this.Database.Projects.Select(p => p.Id).ToList();
            var employeeIds = this.Database.Employees.Select(e => e.Id).ToList();

            this.Logger.Log("\nAdding Employees and projects....\n");

            int counter = 0;
            foreach (var employeeId in employeeIds)
            {
                var currentEmployeeProject = this.CreateItem(employeeId, projectIds);

                this.Database.EmployeesProjects.Add(currentEmployeeProject);

                if (counter % 100 == 0)
                {
                    this.Database.SaveChanges();
                    this.Logger.Log("@");
                }
            }

            this.Logger.Log("\nEmployees and projects added :)");
        }

        private EmployeesProject CreateItem(int employeeId, List<int> projectIds)
        {
            var startDate = this.RandomProvider.GetRandomDate(1970);
            var endDate = this.RandomProvider.GetRandomDate(startDate);

            return new EmployeesProject()
            {
                EmployeeId = employeeId,
                ProjectId = projectIds[this.RandomProvider.GetRandomInt(0, projectIds.Count - 1)],
                StartingDate = startDate,
                EndingDate = endDate
            };
        }
    }
}