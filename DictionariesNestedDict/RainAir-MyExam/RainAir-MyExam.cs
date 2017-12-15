using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainAir_MyExam
{
    class NameComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return string.Compare(x, y, false);
        }
    }

    class RainAir_MyExam
    {
        static void Main(string[] args)
        {
            var flightsInfo = new Dictionary<string, List<long>>();
            var input = Console.ReadLine();

            while (input != "I believe I can fly!")
            {
                var tokens = input.Split(new[] { ' ', '=', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                if (!input.Contains("="))
                {
                    string customerName = tokens[0];

                    if (!flightsInfo.ContainsKey(customerName))
                    {
                        flightsInfo[customerName] = new List<long>();
                    }

                    for (int i = 1; i < tokens.Length; i++)
                    {
                        flightsInfo[customerName].Add(long.Parse(tokens[i]));
                    }
                }
                else
                {
                    var customerOne = tokens[0];
                    var customerTwo = tokens[1];

                    //make the 1st customer’s flights equal to the 2nd customer’s flights
                    //flightsInfo[customerOne] = flightsInfo[customerTwo];

                    flightsInfo[customerOne].Clear();
                    flightsInfo[customerOne].AddRange(flightsInfo[customerTwo]);
                }

                input = Console.ReadLine();
            }

            var ordered = flightsInfo.OrderByDescending(e => e.Value.Count).ThenBy(e => e.Key).ThenBy(n => n.Key, new NameComparer());
            var orderedInner = flightsInfo.OrderBy(e => e.Value);

            foreach (var item in ordered)
            {
                Console.WriteLine($"#{item.Key} ::: {string.Join(", ", item.Value.OrderBy(a => a))}");
            }

        }
    }
}

