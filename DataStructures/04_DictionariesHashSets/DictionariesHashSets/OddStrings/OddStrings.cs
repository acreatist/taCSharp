using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddStrings
{
    class OddStrings
    {
        static void Main(string[] args)
        {
            List<string> strings = new List<string>{"C#", "SQL", "PHP", "PHP", "SQL", "SQL"};

            IDictionary<string, int> occurancies = new SortedDictionary<string, int>();

            foreach (var word in strings)
            {
                if (occurancies.ContainsKey(word))
                {
                    occurancies[word]++;
                }
                else
                {
                    occurancies[word] = 1;
                }
            }

            Console.Write("Odd strings occurancies: { ");
            foreach (var occurance in occurancies)
            {
                if (occurance.Value % 2 != 0)
                {
                    Console.Write("{0} ", occurance.Key);                           
                }
            }
            Console.Write("}\n");
        }
    }
}
