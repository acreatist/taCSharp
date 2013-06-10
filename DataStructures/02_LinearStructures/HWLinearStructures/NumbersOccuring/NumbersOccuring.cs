using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersOccuring
{
    class NumbersOccuring
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 3, 4, 4, 2, 3, 3, 4, 3, 2 };

            // uncomment for console input
            //numbers = GetInput();
            
            Dictionary<int, int> occurings = FindOccurings(numbers);

            PrintNumbers(occurings);
        }

        private static Dictionary<int, int> FindOccurings(List<int> numbers)
        {
            Dictionary<int, int> foundOccurings = new Dictionary<int, int>();

            int numbersCount = numbers.Count;
            
            for (int i = 0; i < numbersCount; i++)
            {
                if (!foundOccurings.Keys.Contains(numbers[i]))
                {
                    foundOccurings.Add(numbers[i], 1);
                }
                else
                {
                    foundOccurings[numbers[i]]++;
                }
            }

            return foundOccurings;
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

        private static void PrintNumbers(Dictionary<int, int> list)
        {
            Console.WriteLine("Found occurings:");
            Console.WriteLine("(Number -> Occurings)");
            foreach (var item in list)
            {
                Console.WriteLine(item.Key + " -> " + item.Value + " times");
            }
            Console.WriteLine();
        }
    }
}
