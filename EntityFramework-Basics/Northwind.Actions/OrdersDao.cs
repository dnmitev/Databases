namespace Northwind.Actions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Northwind.Data;

    public static class OrdersDao
    {
        public static IEnumerable<object> GetSales(string region, DateTime from, DateTime to)
        {
            using (var db = new NorthwindEntities())
            {
                var sales = db.Orders
                              .Where(s => s.ShipRegion == region && s.OrderDate >= from && s.OrderDate <= to)
                              .Select(s => new
                              {
                                  ShipName = s.ShipName,
                                  OrderDate = s.OrderDate
                              })
                              .ToList();

                return sales;
            }
        }

        public static void InsertOrder(
            string shipName, string shipAddress,
            string shipCity, string shipRegionm,
            string shipPostalCode, string shipCountry,
            string customerID = null, int? employeeID = null,
            DateTime? orderDate = null, DateTime? requiredDate = null,
            DateTime? shippedDate = null, int? shipVia = null,
            decimal? freight = null)
        {
            using (var db = new NorthwindEntities())
            {
                Order newOrder = new Order
                {
                    ShipAddress = shipAddress,
                    ShipCity = shipCity,
                    ShipCountry = shipCountry,
                    ShipName = shipName,
                    ShippedDate = shippedDate,
                    ShipPostalCode = shipPostalCode,
                    ShipRegion = shipRegionm,
                    ShipVia = shipVia,
                    EmployeeID = employeeID,
                    OrderDate = orderDate,
                    RequiredDate = requiredDate,
                    Freight = freight,
                    CustomerID = customerID
                };

                db.Orders.Add(newOrder);
                db.SaveChanges();
            }
        }
    }
}