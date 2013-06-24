using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForLoopsRecursion
{
    class ForLoopsRecursion
    {
        static void Main(string[] args)
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());

            int[] nums = new int[n];

            //LoopRecursion(nums, n - 1, n);
            LoopRecursionBackwards(nums, 0);
        }

        private static void LoopRecursion(int[] nums, int currIndex, int end)
        {
            if (currIndex == -1)
            {
                PrintNums(nums);
            }
            else
            {
                for (int i = 1; i <= end; i++)
                {
                    nums[currIndex] = i;
                    LoopRecursion(nums, currIndex - 1, end);
                }
            }
        }

        private static void LoopRecursionBackwards(int[] nums, int currIndex)
        {
            if (currIndex == nums.Length)
            {
                PrintNums(nums);    
                return;
            }

            for (int i = 1; i <= nums.Length; i++)
            {
                nums[currIndex] = i;
                LoopRecursionBackwards(nums, currIndex + 1);
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
