using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddProduct
{
    class AddProduct
    {
        static void Main(string[] args)
        {
            //Write a method that adds a new product in the products table in the Northwind database. Use a parameterized SQL command

            SqlConnection db = new SqlConnection("Server=.; Database=NORTHWND; Integrated Security=true");
            
            // Uncomment if express:
            // SqlConnection db = new SqlConnection("Server=SQLEXPRESS; Database=NORTHWND; Integrated Security=true");

            db.Open();
            using (db)
            {
                SqlCommand addProduct = new SqlCommand("INSERT Products (ProductName,Discontinued) VALUES(@name,@discontinued);", db);

                addProduct.Parameters.AddWithValue("@name", "New Product");
                addProduct.Parameters.AddWithValue("@discontinued", true);
                addProduct.ExecuteNonQuery();

                SqlCommand viewTheProduct = new SqlCommand("SELECT ProductID FROM Products WHERE ProductName='New Product'", db);
                SqlDataReader reader = viewTheProduct.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        int productId = (int)reader["ProductID"];
                        Console.WriteLine("Added Product ID: {0}", productId);
                    }
                }
            }
        }
    }
}
