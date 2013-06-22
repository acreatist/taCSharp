using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinationsDuplicates
{
    class CombinationsDuplicates
    {
        static void Main(string[] args)
        {
            int stringsCount = 3, k = 2;
            int[] combinations = new int[k];
            string[] strings = new string[3]{"hi", "a", "b"};

            GenerateCombinations(combinations, 0, 1, stringsCount, strings);
        }

        private static void GenerateCombinations(int[] combinations, int currIndex, int start, int stringsCount, string[] strings)
        {
            if (currIndex == combinations.Length)
            {
                PrintNums(combinations, strings);
                return;
            }

            for (int i = start; i <= stringsCount; i++)
            {
                combinations[currIndex] = i;
                GenerateCombinations(combinations, currIndex + 1, 1, stringsCount, strings);
            }
        }

        private static void PrintNums(int[] nums, string[] strings)
        {
            foreach (var num in nums)
            {
                Console.Write("{0} ", strings[num-1]);
            }
            Console.WriteLine();
        }
    }
}
