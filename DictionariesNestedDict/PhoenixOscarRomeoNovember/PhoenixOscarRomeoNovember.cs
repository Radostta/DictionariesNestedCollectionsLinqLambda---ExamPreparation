using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoenixOscarRomeoNovember
{
    class PhoenixOscarRomeoNovember
    {
        static void Main(string[] args)
        {
            var creatures = new Dictionary<string, HashSet<string>>(); //HashSet -> in order to keep unique values only
            List<string> check = new List<string>();

            var input = Console.ReadLine();

            while (input != "Blaze it!")
            {
                var data = input.Split(" ->\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                string creature = data[0];
                string squadMate = data[1];
                check.Add(squadMate + " " + creature);

                if (!creatures.ContainsKey(creature))
                {
                    creatures.Add(creature, new HashSet<string>());
                }
                

                if (creature == squadMate || check.Contains(creature + " " + squadMate))
                {
                    creatures[squadMate].Remove(creature); //reversing them as we are checking them reversed in this list
                    input = Console.ReadLine();
                    continue;
                }

                //no need to check if unique, as squadMates are in a HashSet
                creatures[creature].Add(squadMate);

                input = Console.ReadLine();
            }

            foreach (var item in creatures.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{item.Key} : {item.Value.Count}");
            }
        }
    }
}
