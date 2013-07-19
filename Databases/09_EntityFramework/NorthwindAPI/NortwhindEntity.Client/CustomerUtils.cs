using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindEntity.Model;

namespace NortwhindEntity.Client
{
    public class CustomerUtils
    {
        public static void InsertCustomer(string id, string company, string name, string title = null, string address = null,
               string city = null, string postal = null, string country = null, string phone = null, string fax = null)
        {
            NORTHWNDEntities db = new NORTHWNDEntities();

            using (db)
            {
                Customer newCustomer = new Customer
                {
                    CustomerID = id,
                    CompanyName = company,
                    ContactName = name,
                    ContactTitle = null,
                    Address = null,
                    City = null,
                    PostalCode = null,
                    Country = null,
                    Phone = null,
                    Fax = null
                };
                db.Customers.Add(newCustomer);
                db.SaveChanges();
            }
        }

        public static string RemoveCustomer(string id)
        {
            NORTHWNDEntities db = new NORTHWNDEntities();

            using (db)
            {
                var customer = db.Customers.Find(id);
                CustomerData customerToRemove = new CustomerData(customer.CustomerID, customer.ContactName);

                db.Customers.Remove(customer);
                db.SaveChanges();

                return customerToRemove.Name;
            }
        }

        public static string ModifyCustomer(string id, string name = null, string title = null, string address = null,
               string city = null, string postal = null, string country = null, string phone = null, string fax = null)
        {
            NORTHWNDEntities db = new NORTHWNDEntities();

            using (db)
            {
                var customer = db.Customers.Find(id);
                CustomerData customerToModify = new CustomerData(customer.CustomerID, customer.ContactName);

                if (name != null)
                {
                    customer.ContactName = name;
                }

                if (title != null)
                {
                    customer.ContactTitle = title;
                }

                if (address != null)
                {
                    customer.Address = address;
                }

                if (city != null)
                {
                    customer.City = city;
                }

                if (postal != null)
                {
                    customer.PostalCode = postal;
                }

                if (country != null)
                {
                    customer.Country = country;
                }

                if (phone != null)
                {
                    customer.Phone = phone;
                }

                if (fax != null)
                {
                    customer.Fax = fax;
                }

                db.SaveChanges();
                return customerToModify.Name;
            }
        }

        public static List<Customer> GetCustomersByOrdersList(List<Order> ordersList)
        {
            NORTHWNDEntities db = new NORTHWNDEntities();

            List<Customer> allCustomers = new List<Customer>();
            using (db)
            {
                allCustomers = db.Customers.ToList();
            }
            
            var foundCustomersIds = allCustomers.Select(id => id.CustomerID).Intersect(ordersList.Select(id => id.CustomerID));

            var found = allCustomers.Where(o => foundCustomersIds.Contains(o.CustomerID));

            return found.ToList();
        }
    }
}
