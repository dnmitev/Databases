namespace Company.Utilities.DataGenerators
{
    using System;
    using System.Linq;
    using Company.Data;
    using Company.Utilities.Contracts;

    public class EmployeeDataGenerator : DataGenerator
    {
        private const int PercentOfEmployeesWithManagaer = 95;

        public EmployeeDataGenerator(IRandomProvider randomProvider, ILogger<string> logger, DatabaseContext database, int count) : base(randomProvider, logger, database, count)
        {
        }

        public override void Generate()
        {
            var departamentsIds = this.Database.Departments.Select(d => d.Id).ToList();

            this.Logger.Log("\nAdding Employees...\n");
            for (int i = 0; i < this.Count; i++)
            {
                var departmentId = departamentsIds[this.RandomProvider.GetRandomInt(0, departamentsIds.Count - 1)];

                var currentEmployee = CreateItem(departmentId);

                this.Database.Employees.Add(currentEmployee);

                if (i % 100 == 0 && i != 0)
                {
                    this.Database.SaveChanges();
                    this.Logger.Log("*");
                }
            }

            this.Logger.Log("\nEmployees added :)");
        }

        private Employee CreateItem(int departmentId)
        {
            return new Employee()
            {
                FirstName = this.RandomProvider.GetRandomLengthString(5, 20),
                LastName = this.RandomProvider.GetRandomLengthString(5, 20),
                YearSalary = this.RandomProvider.GetRandomPrice(50000, 200000),
                DepartmentId = departmentId,
                //ManagerId = this.RandomProvider.GetRandomPercent() < PercentOfEmployeesWithManagaer ? this.GetEmployeeManager() : (int?)null
            };
        }

        private int GetEmployeeManager()
        {
            var employeesIds = this.Database.Employees.Select(e => e.Id).ToList();

            int managerId = employeesIds[this.RandomProvider.GetRandomInt(0, employeesIds.Count - 1)];
           
            return managerId;
        }
    }
}