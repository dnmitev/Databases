namespace Company.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Company.Utilities.DataGenerators;
    using Company.Utilities.Contracts;

    public class GeneratorFactory
    {
        private const int DepartmentsTotalCount = 100;
        private const int EmployeesTotalCount = 5000;
        private const int AverageReportsPerEmployee = 50;
        private const int EmployeeProjectsStuff = 20000;
        private const int ProjectsTotalCount = 1000;

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
                new DeparmentDataGenerator(this.randomProvider,this.logger,this.database,DepartmentsTotalCount),
                new EmployeeDataGenerator(this.randomProvider,this.logger,this.database,EmployeesTotalCount),
                new ProjectDataGenerator(this.randomProvider,this.logger,this.database,ProjectsTotalCount),
                new EmployessProjectsDataGenerator(this.randomProvider,this.logger,this.database,EmployeeProjectsStuff),
                new ReportDataGenerator(this.randomProvider,this.logger,this.database,AverageReportsPerEmployee),
                new ManagerGenerator(this.randomProvider,this.logger,this.database,EmployeesTotalCount)
            };
        }
    }
}