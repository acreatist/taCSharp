using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFPerformance.Model;

namespace EFPerformance.Client
{
    class EFPerformanceConsole
    {
        static void Main(string[] args)
        {
            TelerikAcademyEntities db = new TelerikAcademyEntities();

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
                        var employeesWithoutInclude = GetEmployeesWithoutInclude(db);
                        PrintEmployees(employeesWithoutInclude);
                        break;
                    case 2:
                        var employeesWithInclude = GetEmployeesWithInclude(db);
                        PrintEmployees(employeesWithInclude);
                        break;
                    case 3:
                        var townsMultipleToList = GetTownsMultipleToList(db);
                        PrintTowns(townsMultipleToList);
                        break;
                    case 4:
                        var townsToListAtEnd = GetTownsToListAtEnd(db);
                        PrintTowns(townsToListAtEnd);
                        break;
                    default:
                        Console.WriteLine("Will exit");
                        input = false;
                        break;
                }
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Please, make a selection:");
            Console.WriteLine("Not Uising/Using Include when selecting");
            Console.WriteLine("1: Print All Employees, not using Include");
            Console.WriteLine("2: Print All Employees, using Include");
            Console.WriteLine("---------\nUsing .ToList()");
            Console.WriteLine("3: Print All Employees, using ToList() after each join");
            Console.WriteLine("4: Print All Employees, using ToList() at the end");

            Console.Write("\nYour choise (1-4): ");
        }

        private static void PrintEmployees(IQueryable<Employee> employees)
        {
            int row = 1;
            foreach (var empl in employees)
            {
                Console.WriteLine();
                Console.WriteLine("{3}. Name: {0} {1} {2}", empl.FirstName, empl.MiddleName, empl.LastName, row);
                Console.WriteLine("Department: {0}", empl.Department.Name);
                Console.WriteLine("Town {0}", empl.Address.Town.Name);

                row++;
            }
        }

        private static void PrintTowns(IEnumerable<Town> towns)
        {
            int row = 1;
            foreach (var town in towns)
            {
                Console.WriteLine();
                Console.WriteLine("{1}. Town: {0}", town.Name, row);
                
                row++;
            }
        }
  
        private static IQueryable<Employee> GetEmployeesWithoutInclude(TelerikAcademyEntities db)
        {
            var employees =
                           from empl in db.Employees
                           select empl;

            return employees;
        }

        private static IQueryable<Employee> GetEmployeesWithInclude(TelerikAcademyEntities db)
        {
            var employees = db.Employees
                .Include("Address.Town")
                .Include("Department");

            return employees;
        }

        private static IEnumerable<Town> GetTownsToListAtEnd(TelerikAcademyEntities db)
        {
            List<Employee> results = new List<Employee>();

            var employees = db.Employees.ToList()
                .Select(e => e.Address).ToList()
                .Select(e => e.Town).ToList()
                .Where(e => e.Name == "Sofia").ToList();

            return employees;
        }

        private static IEnumerable<Town> GetTownsMultipleToList(TelerikAcademyEntities db)
        {
            var employees = db.Employees
                .Select(e => e.Address)
                .Select(e => e.Town)
                .Where(t => t.Name == "Sofia").ToList();

            return employees;
        }
    }
}
