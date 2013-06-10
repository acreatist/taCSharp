using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatternSeuqence
{
    public class PatternSequence
    {
        static void Main()
        {
            int num = 2;
            int m = 50;

            List<int> numbers = RunPattern(m, num);

            Console.WriteLine(SequenceToString(numbers));
        }
  
        public static List<int> RunPattern(int m, int num)
        {
            Queue<int> pivotPoints = new Queue<int>();
            List<int> sequence = new List<int>();

            pivotPoints.Enqueue(num);
            sequence.Add(num);

            int step = 1;
            while(step < m)
            {
                int pivotPoint = pivotPoints.Dequeue();
                
                int numS1 = pivotPoint + 1;
                pivotPoints.Enqueue(numS1);
                sequence.Add(numS1);
                step++;

                int numS2 = 2 * pivotPoint + 1;
                pivotPoints.Enqueue(numS2);
                sequence.Add(numS2);
                step++;

                int numS3 = pivotPoint + 2;
                pivotPoints.Enqueue(numS3);
                sequence.Add(numS3);
                step++;
            }
            return sequence;
        }

        public static string SequenceToString(List<int> sequence)
        {
            StringBuilder output = new StringBuilder();

            output.Append(sequence[0]);
            for (int i = 1; i < sequence.Count; i++)
            {
                output.Append(", " + sequence[i]);
            }

            return output.ToString();
        }
    }
}
