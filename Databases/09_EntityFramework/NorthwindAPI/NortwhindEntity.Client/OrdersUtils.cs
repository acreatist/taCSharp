using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Objects;
using NorthwindEntity.Model;
using System.Transactions;

namespace NortwhindEntity.Client
{
    class OrdersUtils
    {
        public static List<Order> FindOrderByDate(DateTime date)
        {
            NORTHWNDEntities db = new NORTHWNDEntities();
            List<Order> foundOrders = new List<Order>();

            using(db)
	        {
                var ordersByDate =
                    from orders in db.Orders
                    where orders.OrderDate > date
                    select orders;

                foundOrders = ordersByDate.ToList();
	        }

            return foundOrders;
        }

        public static List<Order> FindOrderByCountry(string country)
        {
            
            List<Order> foundOrders = new List<Order>();

            NORTHWNDEntities db = new NORTHWNDEntities();

            using (db)
            {
                var ordersByCountry =
                    from orders in db.Orders
                    where orders.ShipCountry == country
                    select orders;

                foundOrders = ordersByCountry.ToList();
            }

            return foundOrders;
        }

        public static List<string> FindOrderByRegion(string region, DateTime startDate, DateTime endDate)
        {
            NORTHWNDEntities db = new NORTHWNDEntities();

            List<string> result = new List<string>();

            using (db)
            {
                // Thx to vic.alexiev form here http://forums.academy.telerik.com/107782/databases-%D0%B4%D0%BE%D0%BC%D0%B0%D1%88%D0%BD%D0%BE-entity-framework-2-5-%D0%B7%D0%B0%D0%B4%D0%B0%D1%87%D0%B8
                var salesResult =
                    from salesByYear in db.Sales_by_Year(startDate, endDate)
                    join orders in db.Orders.Where(o => o.ShipRegion == region)
                    on salesByYear.OrderID equals orders.OrderID
                    select salesByYear;

                
                foreach (var sale in salesResult)
                {
                    result.Add(String.Format("{0} | {1} | {2} | {3}", sale.OrderID, sale.ShippedDate, sale.Subtotal, sale.Year));
                }
            }

            Console.WriteLine();

            return result;
        }

        public static void AddOrders(Order[] orders)
        {
            NORTHWNDEntities db = new NORTHWNDEntities();
            bool success = false;

            using (TransactionScope dbscope = new TransactionScope())
            {
                //try
                //{
                    foreach (var order in orders)
                    {
                        Order_Detail orderDetails = new Order_Detail() { Quantity = 1 };
                        orderDetails.Order = order;
                        orderDetails.Product = db.Products.FirstOrDefault(p => p.ProductID == 1);

                        db.Orders.Add(order);
                        db.Order_Details.Add(orderDetails);
                    }

                    db.SaveChanges();

                    dbscope.Complete();
                    success = true;
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine("An error occured. "
                //        + "The operation cannot be retried."
                //        + ex.Message);
                //}
            }

            db.Dispose();
        }
    }
}
