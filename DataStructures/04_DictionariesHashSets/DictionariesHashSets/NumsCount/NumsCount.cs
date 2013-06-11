using System;
using System.Collections.Generic;
using System.Linq;

namespace NumsCount
{
    class NumsCount
    {
        static void Main(string[] args)
        {
            List<double> numbers = new List<double> { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
            IDictionary<double, int> occurancies = new SortedDictionary<double, int>();

            foreach (var num in numbers)
            {
                if (occurancies.ContainsKey(num))
                {   
                    occurancies[num]++;
                }
                else
                {
                    occurancies[num] = 1;
                }
            }

            Console.WriteLine("Occurancies: ");
            foreach (var occurance in occurancies)
            {
                Console.WriteLine("{0} -> {1}", occurance.Key, occurance.Value);
            }
        }
    }
}
