using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using NorthwindEntity.Model;

namespace NortwhindEntity.Client
{
    class NorthwindClient
    {
        /* Use The menu to test the tasks.
         * Task 2: Static methods which provide functionality for inserting, modifying and deleting customers
         * Task 3: Write a method that finds all customers who have orders made in 1997 and shipped to Canada.
         * Task 4: Implement previous by using native SQL query and executing it through the DbContext.
         */

        static void Main()
        {
            bool input = true;
            while (input)
            {
                PrintMenu();
                int choise = 0;

                try
                {
                    choise = Int16.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    choise = 0;
                }

                switch (choise)
                {
                    case 1:
                        InsertCustomer("PESHK", "ACME", "Pesho Kolev");
                        break;
                    case 2:
                        ModifyCustomer("PESHK", "Pesho Veche ne e Kolev");
                        break;
                    case 3:
                        RemoveCustomer("PESHK");
                        break;
                    case 4:
                        PrintCustomersByDateAndCountry(new DateTime(1997,1,1), "Canada");
                        break;
                    case 5:
                        PrintCustomersByDateAndCountryNativeSQL();
                        break;
                    case 6:
                        PrintOrdersByRegionAndDateRange("RJ", new DateTime(1996,7,12), new DateTime(1996,7,30));
                        break;
                    case 7:
                        PrintEmployeeTeritory();
                        break;
                    case 8:
                        AddOrders();
                        break;
                    default:
                        Console.WriteLine("Will exit");
                        input = false;
                        break;
                }   
            }
        }

        private static void PrintEmployeeTeritory()
        {
            NORTHWNDEntities db = new NORTHWNDEntities();

            var employee = db.Employees.FirstOrDefault(e => e.EmployeeID == 1);
            var emplTeritory = employee.Territories;

            foreach (var item in emplTeritory)
            {
                Console.WriteLine(item.TerritoryDescription);
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("Please, make a choise:");
            Console.WriteLine("1 - Insert Customer Pesho Kolev with id=PESHK and company=ACME");
            Console.WriteLine("2 - Modify Customer with id=PESHK");
            Console.WriteLine("3 - Remove Customer with id=PESHK");
            Console.WriteLine("4 - Print Customers From Candada, with orders after 1997");
            Console.WriteLine("5 - Print Customers From Candada, with orders after 1997 WITH Native SQL Query");
            Console.WriteLine("6 - Print Sales for region RJ and between 22.08.1996 and 05.08.1996");
            Console.WriteLine("7 - Will add 3 orders with Region: SF and Date: 17.7.2013");
            Console.WriteLine("\n0 - Will exit");
        }

        // TASK 2 - Modify DB Entry
        private static void ModifyCustomer(string id, string name)
        {
            string modified = CustomerUtils.ModifyCustomer(id, name);
            Console.WriteLine("Modified: {0}", modified);
        }

        // TASK 2 - Remove DB Entry
        private static void RemoveCustomer(string customerId)
        {
            string removedName = CustomerUtils.RemoveCustomer(customerId);
            Console.WriteLine("Removed: {0}", removedName);
        }

        // TASK 2 - Insert DB Entry
        private static void InsertCustomer(string id, string company, string name)
        {
            try
            {
                CustomerUtils.InsertCustomer(id, company, name);
                Console.WriteLine("customer {0} Added.", name);
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                Console.WriteLine("Cannot add entry.\n", ex.Message);
            }
        }

        // THis is for testing purpoises - trying to do some kind of delegating tasks.. it's not the best approach.
        // TASK 3 - Find customers from Canada, who made orders after 1997
        private static void PrintCustomersByDateAndCountry(DateTime date, string country)
        {
            var ordersByDate = OrdersUtils.FindOrderByDate(date);
            var ordersByCountry = OrdersUtils.FindOrderByCountry(country);

            var foundOrdersIds = ordersByDate.Select(id => id.OrderID).Intersect(ordersByCountry.Select(id => id.OrderID));
            var found = ordersByDate.Where(o => foundOrdersIds.Contains(o.OrderID));

            var orders = found.ToList();
            var customersFound = CustomerUtils.GetCustomersByOrdersList(orders);

            Console.WriteLine();

            foreach (var customer in customersFound)
            {
                Console.WriteLine(customer.ContactName);
            }

            Console.WriteLine();
        }

        // TASK 4 - Find customers from Canada, who made orders after 1997, through native SQL Query
        private static void PrintCustomersByDateAndCountryNativeSQL()
        {
            NORTHWNDEntities dbContext = new NORTHWNDEntities();

            string foundCustomersQuery =
                @"SELECT DISTINCT ContactName FROM Orders o JOIN Customers c
                ON o.CustomerID = c.CustomerID
                WHERE o.ShipCountry = 'Canada' AND o.OrderDate > '19970101'";

            var customersFound = dbContext.Database.SqlQuery<string>(foundCustomersQuery);

            foreach (var customer in customersFound)
            {
                Console.WriteLine(customer);
            }

            Console.WriteLine();
        }

        // TASK 5 - Find orders for a given region and date range
        private static void PrintOrdersByRegionAndDateRange(string region, DateTime startDate, DateTime endDate)
        {
            var regionResult = OrdersUtils.FindOrderByRegion(region, startDate, endDate);

            Console.WriteLine();
            foreach (var sale in regionResult)
            {
                Console.WriteLine(sale);
            }
        }

        // TASK 6 - see NorthwindEntity.Twin.Model

        // TASK 8 - By inheriting the Employee entity class create a class which allows employees to access their corresponding territories as property of type



        // Task 9 - Add new order.
        private static void AddOrders()
        {
            // In the current demo, the product, linked to the order is done in the OrdersUrils method...
            Order[] orders = {
                new Order { CustomerID = "PARIS", ShipName = "Ship 121", ShipRegion = "BS", ShippedDate = new DateTime(2013, 7, 17) }
            };

            OrdersUtils.AddOrders(orders);

            Console.WriteLine("Orders added:");
            PrintOrdersByRegionAndDateRange("BS", new DateTime(2013, 7, 16), new DateTime(2013, 7, 18));
            Console.WriteLine();
        }
    }
}
