using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesByContinentCountry
{
    class CitiesByContinentCountry
    {
        static void Main(string[] args)
        {
            var continentsData = new Dictionary<string, Dictionary<string, List<string>>>(); //continent -> country -> cites

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split();
                var continent = tokens[0];
                var country = tokens[1];
                var city = tokens[2];

                if (!continentsData.ContainsKey(continent))
                {
                    continentsData[continent] = new Dictionary<string, List<string>>();
                }

                if (!continentsData[continent].ContainsKey(country))
                {
                    continentsData[continent][country] = new List<string>();
                }

                continentsData[continent][country].Add(city);
            }

            foreach (var continentCountries in continentsData)
            {
                var continentName = continentCountries.Key;
                var countries = continentCountries.Value;

                Console.WriteLine(continentName + ":");

                foreach (var countrycities in countries)
                {
                    var countryName = countrycities.Key;
                    var cities = countrycities.Value;

                    Console.WriteLine($"{countryName} -> {string.Join(", ", cities)}");
                }
            }
        }
    }
}
