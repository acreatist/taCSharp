using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseNumsStack
{
    class ReverseNumsStack
    {
        static void Main()
        {
            Stack<int> numbers = new Stack<int>();

            try
            {
                numbers = GetInput();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                numbers = GetInput();
            }

            int numsLength = numbers.Count;
            for (int i = 0; i < numsLength-1; i++)
            {
                Console.Write(numbers.Pop() + ", ");
            }

            Console.Write(numbers.Pop());
            Console.WriteLine();
        }

        private static Stack<int> GetInput()
        {
            Stack<int> inputNumbers = new Stack<int>();
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

                inputNumbers.Push(number);
            }

            if (inputNumbers.Count < 1)
            {
                throw new ArgumentNullException("inputNumbers", "Need at least one number!");
            }

            return inputNumbers;
        }
    }
}
