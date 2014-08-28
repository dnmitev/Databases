namespace Northwind.Actions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Northwind.Data;

    public static class CustomersDao
    {
        /// <summary>
        /// Insert new customer to the Customer table in Northwind DB
        /// </summary>
        /// <param name="customer">Customer table like</param>
        public static void InsertCustomer(Customer customer)
        {
            using (var db = new NorthwindEntities())
            {
                db.Customers.Add(customer);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Delete entry from the 'Customers' table by its id
        /// </summary>
        /// <param name="customerId">5 char string</param>
        public static void DeleteCustomerById(string customerId)
        {
            using (var db = new NorthwindEntities())
            {
                var customerToDelete = db.Customers.Where(c => c.CustomerID == customerId).FirstOrDefault();
                db.Customers.Remove(customerToDelete);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Change 'Customers' table entry's company name by id 
        /// </summary>
        /// <param name="customerId">5-char string</param>
        /// <param name="newCompanyName">new name as string</param>
        public static void ChangeCustomerCompanyName(string customerId, string newCompanyName)
        {
            using (var db = new NorthwindEntities())
            {
                var customerToAlter = db.Customers.Where(c => c.CustomerID == customerId).FirstOrDefault();
                customerToAlter.CompanyName = newCompanyName;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Get all customers which have orderDate = 1997 and have stock shipped to Canada
        /// </summary>
        /// <returns>Collection of all the company names as strings</returns>
        public static IEnumerable<string> GetAllCustomersWithCriteria()
        {
            using (var db = new NorthwindEntities())
            {
                return db.Orders
                    .Where(o => o.OrderDate.Value.Year == 1997)
                    .Where(o => o.ShipCountry == "Canada")
                    .Select(c => c.Customer.CompanyName)
                    .ToList();
            }
        }

        /// <summary>
        /// Get all customers which have orderDate = 1997 and have stock shipped to Canada USING NATIVE SQL Query
        /// </summary>
        /// <returns>Collection of all the company names as strings</returns>
        public static IEnumerable<string> GetAllCustomersWithCriteriaSql()
        {
            using (var db = new NorthwindEntities())
            {
                object[] parameters = { 1997, "Canada" };
                var query = "SELECT c.CompanyName " +
                            "FROM Orders o " +
                                "INNER JOIN Customers c " +
                                    "ON o.CustomerID = c.CustomerID " +
                                "WHERE YEAR(o.ShippedDate) = {0} AND o.ShipCountry = {1}";
                return db.Database.SqlQuery<string>(query, parameters).ToList();
            }
        }
    }
}