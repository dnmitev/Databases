namespace NorthwindConcurentChanges
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Northwind.Data;
    
    class ConcurencyDealingDemo
    {
        static void Main()
        {
            using (var firstDb = new NorthwindEntities())
            {
                using (var secondDb = new NorthwindEntities())
                {
                    var firstCustomer = firstDb.Customers.Find("CHOPS");
                    firstCustomer.Region = "BG";

                    var secondCustomer = secondDb.Customers.Find("CHOPS");
                    secondCustomer.Region = "TA";

                    firstDb.SaveChanges();
                    secondDb.SaveChanges();
                }
            }
        }
    }
}