// 01. Using Entity Framework write a SQL query to select all employees from the Telerik Academy database and later print their
// name, department and town. Try the both variants: with and without .Include(…). Compare the number of executed SQL statements
// and the performance.

namespace NPlus1Problem
{
    using System;
    using System.Linq;
    using System.Text;
    using TelerikAcademy.Models;
    
    internal class ProblemDemo
    {
        private static void Main()
        {
            GetDataUsingLameWay();

            Console.WriteLine("Press any key to execute the query in the right way.");
            Console.ReadLine();

            GetDataUsingRightWay();
        }
 
        private static void GetDataUsingLameWay()
        {
            using (var telerikAcademyContext = new TelerikAcademyEntities())
            {
                var employees = telerikAcademyContext.Employees;
                StringBuilder output;
                foreach (var employee in employees)
                {
                    output = new StringBuilder();
                    output.AppendLine(string.Format("{0} {1}", employee.FirstName, employee.LastName));
                    output.AppendLine(string.Format("\tDepartment: {0}", employee.Department.Name));
                    output.AppendLine(string.Format("\tTown: {0}", employee.Address.Town.Name));

                    Console.WriteLine(output.ToString());
                }
            }
        }

        private static void GetDataUsingRightWay()
        {
            using (var telerikAcademyContext = new TelerikAcademyEntities())
            {
                var employees = telerikAcademyContext.Employees;
                StringBuilder output;
                foreach (var employee in employees.Include("Department").Include("Address.Town"))
                {
                    output = new StringBuilder();
                    output.AppendLine(string.Format("{0} {1}", employee.FirstName, employee.LastName));
                    output.AppendLine(string.Format("\tDepartment: {0}", employee.Department.Name));
                    output.AppendLine(string.Format("\tTown: {0}", employee.Address.Town.Name));

                    Console.WriteLine(output.ToString());
                }
            }
        }
    }
}