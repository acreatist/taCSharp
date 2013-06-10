using System;
using System.Collections.Generic;
using System.Linq;

namespace SumAverage
{
    class SumAverage
    {
        static void Main()
        {
            List<int> numbers = new List<int>(); //{ 1, 2, 4, 6, 234, 465, 3, 5, 25, 25, 45, 435, 43252, 52, 234234, 5454 };

            numbers = GetInput();

            int sum = GetNumbersSum(numbers);
            int max = GetMaxNumber(numbers);

            Console.WriteLine();
            Console.WriteLine("Max Number = {0}", max);
            Console.WriteLine("Sum of Numbers = {0}", sum);
        }

        private static List<int> GetInput()
        {
            List<int> inputNumbers = new List<int>();
            int number;

            string readLine = "";
            while (true)
            {
                Console.Write("Enter number, or empty to stop: ");
                readLine = Console.ReadLine();

                if (readLine == "")
                {
                    break;
                }
                
                if (!int.TryParse(readLine, out number))
                {
                    Console.WriteLine("Invalid Number!");
                    continue;
                }

                inputNumbers.Add(number);                                
            }

            return inputNumbers;
        }

        private static int GetMaxNumber(List<int> numbers)
        {
            int numsLength = numbers.Count;
            int max = numbers[0];

            for (int i = 1; i < numsLength; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }

            return max;
        }

        private static int GetNumbersSum(List<int> numbers)
        {
            int numsLength = numbers.Count;
            int sum = numbers[0];

            for (int i = 1; i < numsLength; i++)
            {
                sum += numbers[i];
            }

            return sum;
        }
    }
}
