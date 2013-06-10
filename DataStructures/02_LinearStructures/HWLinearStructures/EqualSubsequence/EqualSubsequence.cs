using System;
using System.Collections.Generic;
using System.Linq;

namespace EqualSubsequence
{
    class EqualSubsequence
    {
        static void Main()
        {
            List<int> numbers = new List<int>() { 1,1,1,1,1,1,1,1,1,1,1,1,22,2,2,2,2,2,2,2,44,4,4,4,2,5, 5 };
            
            // uncomment for console input
            //numbers = GetInput();

            List<int> subsequence = new List<int>();

            subsequence = FindEqualSubsequence(numbers);

            foreach (var num in subsequence)
            {
                Console.Write(num + ", ");
            }
        }
  
        private static List<int> FindEqualSubsequence(List<int> numbers)
        {
            List<int> subsequence = new List<int>();

            subsequence.Add(numbers[0]);
            int subsequenceLength = 1;
              
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    subsequenceLength++;

                    if (subsequenceLength > subsequence.Count)
                    {
                        subsequence.Clear();
                        for (int subs = 0; subs < subsequenceLength; subs++)
                        {
                            subsequence.Add(numbers[i]);
                        }
                    }
                }
                else
                {
                    subsequenceLength = 1;
                }
            }

            return subsequence;
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
