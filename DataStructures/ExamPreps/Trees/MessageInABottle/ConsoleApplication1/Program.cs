using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static List<List<string>> combinations = new List<List<string>>();

        static void Main(string[] args)
        {
            string cifer = Console.ReadLine();
            string message = Console.ReadLine();

            int currStart = 0;
            while (currStart < cifer.Length)
            {
                GenerateCombination(cifer, currStart, 1);
                currStart++;
            }

            DeciferMessage(message);
        }

        private static void GenerateCombination(string cifer, int start, int length)
        {
            if (length > cifer.Length - start)
            {
                return;
            }
            List<string> ciferParts = new List<string>();

            if (start > 0)
            {
                ciferParts.Add(cifer.Substring(0, start));    
            }
            
            ciferParts.Add(cifer.Substring(start, length));

            int indexFromEnd = start + length;
            while (indexFromEnd < cifer.Length)
            {
                ciferParts.Add(cifer[indexFromEnd].ToString());
                indexFromEnd++;
            }

            combinations.Add(ciferParts);

            GenerateCombination(cifer, start, length + 1);
        }

        private static Dictionary<string, char> ParseMessage(string message)
        {
            Dictionary<string, char> ciferTable = new Dictionary<string, char>();

            StringBuilder ciferNumber = new StringBuilder();
            char ciferLetter = message[0];

            for (int i = 1; i < message.Length; i++)
            {
                try
                {
                    int digit = int.Parse(message[i].ToString());
                    ciferNumber.Append(message[i]);
                }
                catch (Exception)
                {
                    ciferTable[ciferNumber.ToString()] = ciferLetter;
                    ciferNumber.Clear();
                    ciferLetter = message[i];
                }
            }

            // Add the last one
            ciferTable[ciferNumber.ToString()] = ciferLetter;

            return ciferTable;
        }

        private static void DeciferMessage(string message)
        {   
            Dictionary<string, char> ciferTable = ParseMessage(message);

            SortedSet<string> deciferedMessages = new SortedSet<string>();

            foreach (var combination in combinations)
            {   
                StringBuilder decifered = new StringBuilder();
                string code = "";

                for (int i = 0; i < combination.Count; i++)
                {
                    code = combination[i];
                    if (ciferTable.ContainsKey(code))
                    {
                        decifered.Append(ciferTable[code]);
                    }
                    else
                    {
                        decifered.Clear();
                        break;
                    }
                }
                if (decifered.Length > 0)
                {
                    deciferedMessages.Add(decifered.ToString());    
                }
                
            }

            PrintDeciferedMessages(deciferedMessages);
        }

        private static void PrintDeciferedMessages(SortedSet<string> deciferedMessages)
        {   
            Console.WriteLine(deciferedMessages.Count);
            foreach (var message in deciferedMessages)
            {
                Console.WriteLine(message);
            }
        }
    }

}
