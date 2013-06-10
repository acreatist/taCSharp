using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortNumbers
{
    class SortNumbers
    {
        static void Main()
        {
            List<int> numbers = new List<int>() { 1,5,7,9,3,4,2,6,8 };
            
            // uncomment for console input
            //numbers = GetInput();

            List<int> sortedNumbers = new List<int>();

            sortedNumbers = MergeSort(numbers);

            PrintNumbers(sortedNumbers);
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

        private static void PrintNumbers(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + ", ");
            }
            Console.WriteLine();
        }

        private static List<int> MergeSort(List<int> numbers)
        {
            int numbersCount = numbers.Count;
            if (numbersCount <= 1)
            {
                return numbers;
            }

            List<int> leftSide = new List<int>();
            List<int> rightSide = new List<int>();
            List<int> mergedSorted = new List<int>();
            
            int middleNumber = numbersCount / 2;

            for (int i = 0; i < numbersCount; i++)
            {
                if (i < middleNumber)
                {
                    leftSide.Add(numbers[i]);
                }
                else
                {
                    rightSide.Add(numbers[i]);
                }
            }

            leftSide = MergeSort(leftSide);
            rightSide = MergeSort(rightSide);

            mergedSorted = Merge(leftSide, rightSide);
            
            return mergedSorted;
        }

        private static List<int> Merge(List<int> leftSide, List<int> rightSide)
        {
            List<int> result = new List<int>();

            while (leftSide.Count > 0 || rightSide.Count > 0)
            {
                // Check if both sides has values
                if (leftSide.Count > 0 && rightSide.Count > 0)
                {
                    if (leftSide[0] <= rightSide[0])
                    {
                        result.Add(leftSide[0]);
                        leftSide.RemoveAt(0);
                    }
                    else
                    {
                        result.Add(rightSide[0]);
                        rightSide.RemoveAt(0);
                    }
                }
                // If right side is empty
                else if (leftSide.Count > 0)
                {
                    result.Add(leftSide[0]);
                    leftSide.RemoveAt(0);
                }
                // If left side is empty
                else if (rightSide.Count > 0)
                {
                    result.Add(rightSide[0]);
                    rightSide.RemoveAt(0);
                }
            }

            return result;
        }
    }
}
