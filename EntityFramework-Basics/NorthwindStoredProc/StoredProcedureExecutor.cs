namespace NorthwindStoredProc
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Northwind.Data;
    using Northwind.Data.Migrations;
    using System.Data.Entity;

    class StoredProcedureExecutor
    {
        static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NorthwindEntities,Configuration>());
            Console.WriteLine("bat mitko");
            var totalIncome = GetTotalIncomes("Tokyo Traders", new DateTime(1990, 1, 1), new DateTime(2000, 1, 1));

            Console.WriteLine(totalIncome);
        }

        static decimal? GetTotalIncomes(string supplierName, DateTime? startDate, DateTime? endDate)
        {
            using (var db = new NorthwindEntities())
            {
                var totalIncomesSet = db.usp_GetTotalIncome(supplierName, startDate, endDate);

                foreach (var totalIncome in totalIncomesSet)
                {
                    return totalIncome;
                }

                return null;
            }
        }
    }
}