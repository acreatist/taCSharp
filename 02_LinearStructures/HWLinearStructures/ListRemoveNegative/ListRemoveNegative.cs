using System;
using System.Collections.Generic;
using System.Linq;

namespace ListRemoveNegative
{
    class ListRemoveNegative
    {
        static void Main()
        {
            List<int> numbers = new List<int>() { 1, -2, 3, 4, -5, -2, 123, 134, -123 };

            // uncomment for console input
            //numbers = GetInput();

            int numsLength = numbers.Count;

            for (int i = 0; i < numsLength; i++)
            {
                if (numbers[i] < 0)
                {
                    numbers.RemoveAt(i);

                    // update list count
                    numsLength--;

                    // return a step back, as we strip this index
                    i--;
                }
            }

            PrintNumbers(numbers);
        }

        private static void PrintNumbers(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + ", ");
            }
            Console.WriteLine();
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
    }
}
