using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonEvolutionV2
{
    class PokemonEvolutionV2
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var pokemons = new Dictionary<string, List<string>>();

            while (input != "wubbalubbadubdub")
            {
                string[] pokemonInfo = input.Split(" ->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                if (pokemonInfo.Length == 1)
                {
                    string key = pokemonInfo[0];

                    if (pokemons.ContainsKey(key))
                    {
                        Console.WriteLine($"# {key}");

                        foreach (var item in pokemons[key])
                        {
                            string[] currentPair = item.Split();
                            string type = currentPair[0];
                            long currentIndex = long.Parse(currentPair[1]);

                            Console.WriteLine($"{type} <-> {currentIndex}");
                        }
                    }                    
                }
                else
                {
                    string pokemonName = pokemonInfo[0];
                    string evolutionType = pokemonInfo[1];
                    long evolutionIndex = long.Parse(pokemonInfo[2]);

                    if (!pokemons.ContainsKey(pokemonName))
                    {
                        pokemons.Add(pokemonName, new List<string>());
                    }
                    pokemons[pokemonName].Add(evolutionType + " " + evolutionIndex);
                
                }
                input = Console.ReadLine();
            }

            foreach (var pokemon in pokemons)
            {
                Console.WriteLine($"# {pokemon.Key}");

                foreach (var element in pokemon.Value.OrderByDescending(x => int.Parse(x.Split()[1])))
                {
                    string[] result = element.Split();
                    Console.WriteLine($"{result[0]} <-> {result[1]}");
                }
            }
        }
    }
}
