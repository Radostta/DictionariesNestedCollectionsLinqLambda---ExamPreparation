using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddOccurrences
{
    class OddOccurrences
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine().Split(new[] { ' '}, StringSplitOptions.RemoveEmptyEntries);
            var oddOccurrences = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                string currentWord = words[i].ToLower();               

                if (oddOccurrences.ContainsKey(currentWord))
                {
                    oddOccurrences[currentWord]++;
                }
                else
                {
                    oddOccurrences.Add(currentWord, 1);
                }
            }

            var wordsWithOddOccurrences = new List<string>();

            foreach (var word in oddOccurrences.Where(x => x.Value % 2 != 0))
            {
                wordsWithOddOccurrences.Add(word.Key);
            }

            Console.WriteLine(string.Join(", ", wordsWithOddOccurrences));
        }
    }
}
