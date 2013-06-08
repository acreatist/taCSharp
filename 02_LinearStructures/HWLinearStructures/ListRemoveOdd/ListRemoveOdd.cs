using System;
using System.Collections.Generic;
using System.Linq;

/*
 * Yes, I know there's a better way with Dictionary, or Stack (didn't get it...)
 * but it's already posted on the forum. YKWM :)
 */

namespace ListRemoveOdd
{
    class ListRemoveOdd
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 1, 5, 2 };

            // uncomment for console input
            //numbers = GetInput();

            List<int> strippedNumbers = StripOddOcurrances(numbers);

            PrintNumbers(strippedNumbers);
        }

        private static List<int> StripOddOcurrances(List<int> inputNumbers)
        {   
            // Copy numbers to a temp list
            List<int> numbers = new List<int>();
            foreach (var num in inputNumbers)
            {
                numbers.Add(num);
            }

            // Store numbers to remove
            List<int> numsToRemove = new List<int>();

            int currNumber = numbers[0];
            int currOccurance = 1;
            
            int numbersLength = numbers.Count;
            for (int i = 1; i < numbersLength; i++)
            {
                if (numbers[i] == currNumber)
                {
                    currOccurance++;
                }

                // Remove oserved number and restart the loop
                // TODO: could be made with a recursion...
                if (i == numbersLength - 1)
                {
                    if (currOccurance % 2 != 0)
                    {
                        numsToRemove.Add(currNumber);
                    }

                    numbers.RemoveAll(num => num == currNumber);
                    numbersLength = numbers.Count;

                    // If we've cycled all numbers - break;
                    if (numbersLength == 0)
                    {
                        break;
                    }

                    i = 0;
                    currNumber = numbers[0];
                    currOccurance = 1;
                }
            }

            // Check if anything is left in the sequence:
            if (numbers.Count > 0)
            {
                numsToRemove.Add(numbers[0]);
            }
            
            foreach (var numberToRemove in numsToRemove)
            {
                inputNumbers.RemoveAll(num => num == numberToRemove);
            }

            return inputNumbers;
        }

        private static List<int> GetInput()
        {
            List<int> inputNumbers = new List<int>();
            int number;

            string readLine = "";
            string[] numbersString;
            while (true)
            {
                Console.Write("Enter numbers, separated by space: ");
                readLine = Console.ReadLine();
                numbersString = readLine.Split(' ');

                foreach (var num in numbersString)
                {
                    if (!int.TryParse(num, out number))
                    {
                        Console.WriteLine("Invalid Number!");
                        continue;
                    }

                    inputNumbers.Add(number);
                }

                break;
            }

            return inputNumbers;
        }

        private static void PrintNumbers(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + ", ");
            }
            Console.WriteLine();
        }
    }
}