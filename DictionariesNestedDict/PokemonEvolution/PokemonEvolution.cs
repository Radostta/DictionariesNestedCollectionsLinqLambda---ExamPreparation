using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonEvolution
{
    class PokemonEvolution
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var pokemons = new Dictionary<string, List<string>>();

            while (input != "wubbalubbadubdub")
            {
                string[] tokens = input.Split(new string[] { " -> "}, StringSplitOptions.RemoveEmptyEntries);
                string pokeName = tokens[0];

                if (tokens.Length > 1)
                {
                    if (!pokemons.ContainsKey(pokeName))
                    {
                        pokemons[pokeName] = new List<string>();
                    }
                    string pointsEvolutionType = tokens[1] + " <-> " + int.Parse(tokens[2]);
                    pokemons[pokeName].Add(pointsEvolutionType);
                }
                else
                {
                    if (pokemons.ContainsKey(pokeName))
                    {
                        Console.WriteLine("# " + pokeName);
                        foreach (string evolution in pokemons[pokeName])
                        {
                            Console.WriteLine(evolution);
                        }
                    }
                }               
                input = Console.ReadLine();
            }

            foreach (var item in pokemons)
            {
                Console.WriteLine("# " + item.Key);

                foreach (string typeAndNumber in item.Value.OrderByDescending(x => int.Parse(x.Split(new[] { " <-> "}, StringSplitOptions.None).Skip(1).First())))
                {
                    Console.WriteLine(typeAndNumber);
                }
            }
        }
    }
}
