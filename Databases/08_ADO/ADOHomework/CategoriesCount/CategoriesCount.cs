using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoriesCount
{
    class CategoriesCount
    {
        static void Main(string[] args)
        {
            //Write a program that retrieves from the Northwind sample database in MS SQL Server
            //the number of  rows in the Categories table.

            SqlConnection db = new SqlConnection("Server=.; Database=NORTHWND; Integrated Security=true");
            
            // Uncomment if express:
            // SqlConnection db = new SqlConnection("Server=SQLEXPRESS; Database=NORTHWND; Integrated Security=true");

            db.Open();
            using (db)
            {
                SqlCommand queryCategoriesCount = new SqlCommand("SELECT COUNT(CategoryID) FROM Categories", db);
                
                int categoriesCount = (int)queryCategoriesCount.ExecuteScalar();
                
                Console.WriteLine("Items in Categories: {0}", categoriesCount);
            }
        }
    }
}
