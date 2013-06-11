using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReadWords
{
    class ReadWords
    {
        static void Main(string[] args)
        {
            StreamReader wordsFile = new StreamReader("words.txt");
            StringBuilder wordsStr = new StringBuilder();
            using (wordsFile)
            {
                while (!wordsFile.EndOfStream)
                {
                    wordsStr.Append(wordsFile.ReadLine());                           
                }
            }

            char[] separators = { ' ', ',', '.', '!', '-', '?' };
            string[] words = wordsStr.ToString().Split(separators, StringSplitOptions.RemoveEmptyEntries);

            IDictionary<string, int> wordsCount = new SortedDictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);

            foreach (var word in words)
            {
                if (wordsCount.ContainsKey(word))
                {   
                    wordsCount[word]++;
                }
                else
                {
                    wordsCount[word] = 1;
                }
            }

            Console.WriteLine("Words count: ");
            foreach (var word in wordsCount)
            {
                Console.WriteLine("{0} -> {1}", word.Key, word.Value);
            }
        }
    }
}
