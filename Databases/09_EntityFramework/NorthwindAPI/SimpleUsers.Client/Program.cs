using System;
using System.Collections.Generic;
using System.Linq;
using SimpleUsers.Model;
using System.Transactions;
using System.Data.SqlClient;

namespace SimpleUsers.Client
{
    class Program
    {
        static void Main()
        {
            string inputUsername = String.Empty;
            string inputPassword = String.Empty;
            string inputGroup = String.Empty;
            string createAnother = String.Empty;
            bool loop = true;

            while (loop)
            {
                Console.WriteLine("Cretate a new user");
                
                Console.Write("Username: ");
                inputUsername = Console.ReadLine();

                Console.Write("Password: ");
                inputPassword = Console.ReadLine();

                Console.Write("Group Name: ");
                inputGroup = Console.ReadLine();
    
                CreateUser(inputUsername, inputPassword, inputGroup);

                Console.WriteLine("\nCreate another?");
                Console.Write("y/n: ");
                createAnother = Console.ReadLine();

                Console.WriteLine();

                if (createAnother == "n")
                {
                    loop = false;
                }
            }
            
        }

        private static void CreateUser(string username, string password, string group)
        {
            SimpleUsersEntities dbContext = new SimpleUsersEntities();

            try
            {
                using (TransactionScope dbScope = new TransactionScope())
                {
                    User user = new User
                    {
                        username = username,
                        userpass = password
                    };
                    
                    Group admins = dbContext.Groups.FirstOrDefault(g => g.Name == group);

                    if (admins == null)
                    {
                        admins = new Group { Name = group, Users = new HashSet<User>() };
                        dbContext.Groups.Add(admins);
                    }
                    else
                    {
                        dbContext.Groups.Attach(admins);
                    }

                    admins.Users.Add(user);

                    dbContext.SaveChanges();
                    dbScope.Complete();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: {0}", ex.Message);
            }
        }
    }
}
