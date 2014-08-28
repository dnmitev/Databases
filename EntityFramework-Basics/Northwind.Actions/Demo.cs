namespace Northwind.Actions
{
    using Northwind.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Transactions;

    public class Demo
    {
        static void Main()
        {
            var customer = new Customer()
            {
                CustomerID = "4AlGA",
                CompanyName = "Payner"
            };

            CustomersDao.InsertCustomer(customer);

            Console.WriteLine("Entry added to the 'Customers' table. Press any key to change the entry");
            //Console.ReadKey();

            CustomersDao.ChangeCustomerCompanyName("4AlGA", "ARA Music");

            Console.WriteLine("Entry changed in the 'Customers' table. Press any key to continue");
            //Console.ReadKey();

            CustomersDao.DeleteCustomerById("4AlGA");

            Console.WriteLine("Entry deleted from the 'Customers' table. Press any key continue");
            //Console.ReadKey();

            var customers = CustomersDao.GetAllCustomersWithCriteria();
            Console.WriteLine(string.Join(", ", customers));

            var sales = OrdersDao.GetSales("DF", new DateTime(1996, 7, 15), new DateTime(1996, 8, 15));
            foreach (var sale in sales)
            {
                Console.WriteLine(sale);
            }

            using (var transactionScope = new TransactionScope())
            {
                using (var db = new NorthwindEntities())
                {
                    for (int i = 0; i < 5; i++)
                    {
                        OrdersDao.InsertOrder("Bat Joro" + i, i + " ,Mariika Str", "Kaspichan", "Tam-Nyakude", "AZDA", "Bulgaria");
                    }
                }

                transactionScope.Complete();
            }
        }
    }
}