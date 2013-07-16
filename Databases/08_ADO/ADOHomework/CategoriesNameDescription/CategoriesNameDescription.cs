using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoriesNameDescription
{
    class CategoriesNameDescription
    {
        static void Main(string[] args)
        {
            //Write a program that retrieves the name and description of all categories in the Northwind DB.

            SqlConnection db = new SqlConnection("Server=.; Database=NORTHWND; Integrated Security=true");
            
            // Uncomment if express:
            // SqlConnection db = new SqlConnection("Server=SQLEXPRESS; Database=NORTHWND; Integrated Security=true");

            db.Open();
            using (db)
            {
                SqlCommand queryCategories = new SqlCommand("SELECT CategoryName, Description FROM Categories", db);

                SqlDataReader reader = queryCategories.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        string catName = (string)reader["CategoryName"];
                        string catDesc = (string)reader["Description"];
                        Console.WriteLine("Category Name: {0} \nDescription: {1}", catName, catDesc);
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
