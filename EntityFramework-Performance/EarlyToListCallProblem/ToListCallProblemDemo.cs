// 02. Using Entity Framework write a query that selects all employees from the Telerik Academy database, then invokes ToList(), 
// then selects their addresses, then invokes ToList(), then selects their towns, then invokes ToList() and finally checks whether 
// the town is "Sofia". Rewrite the same in more optimized way and compare the performance.

namespace EarlyToListCallProblem
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TelerikAcademy.Models;

    class ToListCallProblemDemo
    {
        static void Main()
        {
            var sw = new Stopwatch();
            sw.Start();
            GetTownBySlowWay();
            sw.Stop();
            Console.WriteLine("Lame way time elapsed: {0}",sw.Elapsed);

            sw.Reset();
            sw.Start();
            GetTownByRightWay();
            sw.Stop();
            Console.WriteLine("Right way time elapssed: {0}",sw.Elapsed);
        }
 
        private static void GetTownBySlowWay()
        {
            var telerikAcademyContext = new TelerikAcademyEntities();

            var townSlowWay = telerikAcademyContext.Employees
                                                   .ToList()
                                                   .Select(e => e.Address)
                                                   .ToList()
                                                   .Select(a => a.Town)
                                                   .ToList()
                                                   .Where(t => t.Name == "Sofia");

            Console.WriteLine(townSlowWay.Count());
        }

        private static void GetTownByRightWay()
        {
            var telerikAcademyContext = new TelerikAcademyEntities();

            var townsRightWay = telerikAcademyContext.Employees
                                                     .Select(e => e.Address)
                                                     .Select(a => a.Town)
                                                     .Where(t => t.Name == "Sofia")
                                                     .ToList();

            Console.WriteLine(townsRightWay.Count());
        }
    }
}