using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonEvolutionV3
{
    public class Evolution
    {
        public string EvoName { get; set; }
        public int EvoIndex { get; set; }

        public Evolution(String evoName, int evoIndex)
        {
            this.EvoName = evoName;
            this.EvoIndex = evoIndex;
        }
    }

    class PokemonEvolutionV3
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var result = new Dictionary<string, List<Evolution>>();

            while (input != "wubbalubbadubdub")
            {
                var tokens = input.Split(" ->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                var pokeName = tokens[0];

                if (tokens.Length > 1)
                {
                    var pokeEvo = tokens[1];
                    var pokeIndex = int.Parse(tokens[2]);

                    var newEvolution = new Evolution(pokeEvo, pokeIndex);

                    //Without a constructor:
                    //var newEvolution = new Evolutions();
                    //newEvolution.EvoName = pokeEvo;
                    //newEvolution.EvoIndex = pokeIndex;

                    if (!result.ContainsKey(pokeName))
                    {
                        result[pokeName] = new List<Evolution>();
                    }
                    result[pokeName].Add(newEvolution);
                }
                else
                {
                    if (result.ContainsKey(pokeName))
                    {
                        Console.WriteLine($"# {pokeName}");
                        foreach (var evolution in result[pokeName])
                        {
                            Console.WriteLine($"{evolution.EvoName} <-> {evolution.EvoIndex}");
                        }
                    }
                }
                input = Console.ReadLine();
            }

            foreach (var name in result)
            {
                Console.WriteLine($"# {name.Key}");
                foreach (var evolution in name.Value.OrderByDescending(x => x.EvoIndex))
                {
                    Console.WriteLine($"{evolution.EvoName} <-> {evolution.EvoIndex}");
                }
            }
            
        }
    }
}
