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
            int numsRangeN = 3, k = 2;
            int[] combinations = new int[k];

            GenerateCombinations(combinations, 0, 1, numsRangeN);
        }

        private static void GenerateCombinations(int[] combinations, int currIndex, int start, int numsRange)
        {
            if (currIndex == combinations.Length)
            {
                PrintNums(combinations);
                return;
            }

            for (int i = start; i <= numsRange; i++)
            {
                combinations[currIndex] = i;
                GenerateCombinations(combinations, currIndex + 1, i, numsRange);
            }
        }

        private static void PrintNums(int[] nums)
        {
            foreach (var num in nums)
            {
                Console.Write("{0} ", num);
            }
            Console.WriteLine();
        }
    }
}
