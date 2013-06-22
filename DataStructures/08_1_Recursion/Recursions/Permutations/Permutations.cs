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
            int numsRangeN = 2, k = 2;
            int[] permutations = new int[k];
            bool[] used = new bool[k+1]; // length is nums+1, as this bool array holds the values, which are already used, not indexes

            GenerateCombinations(permutations, used, 0, 1, numsRangeN);
        }

        private static void GenerateCombinations(int[] permutations, bool[] used, int currIndex, int start, int numsRange)
        {
            if (currIndex == permutations.Length)
            {
                PrintNums(permutations);
                return;
            }

            for (int i = start; i <= numsRange; i++)
            {
                if (used[i] == false)
                {
                    permutations[currIndex] = i;
                    used[i] = true;
                    GenerateCombinations(permutations, used, currIndex + 1, 1, numsRange); // Always start with 1 on next iteration
                    used[i] = false;
                }
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
