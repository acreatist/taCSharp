using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleHashTable.Common;

namespace SimpleHashTable
{
    class SimpleHashTableDemo
    {
        static void Main(string[] args)
        {
            SimpleHashTable<int, int> simpleHashTable = new SimpleHashTable<int, int>();
            simpleHashTable.Add(1, 2);
            simpleHashTable.Add(3, 4);

            try
            {
                Console.WriteLine(simpleHashTable.Find(2));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
        }
    }
}
