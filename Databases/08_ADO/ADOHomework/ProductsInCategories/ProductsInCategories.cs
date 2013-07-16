using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsInCategories
{
    class ProductsInCategories
    {
        static void Main(string[] args)
        {
            //Write a program that retrieves from the Northwind database all product categories and the names of the products in each category. 
            //Can you do this with a single SQL query (with table join)?

            SqlConnection db = new SqlConnection("Server=.; Database=NORTHWND; Integrated Security=true");
            
            // Uncomment if express:
            // SqlConnection db = new SqlConnection("Server=SQLEXPRESS; Database=NORTHWND; Integrated Security=true");

            db.Open();
            using (db)
            {
                SqlCommand joinTable = new SqlCommand("SELECT c.CategoryName, p.ProductName FROM Categories c join Products p on c.CategoryID = p.CategoryID;", db);
                SqlDataReader reader = joinTable.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        string catName = (string)reader["CategoryName"];
                        string productName = (string)reader["ProductName"];
                        Console.WriteLine("{0} in {1}", productName, catName);
                    }
                }
            }
        }
    }
}
