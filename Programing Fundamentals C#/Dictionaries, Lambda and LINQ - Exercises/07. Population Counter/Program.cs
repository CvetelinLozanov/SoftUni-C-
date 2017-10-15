using System;
using System.Linq;
using System.Collections.Generic;

namespace _07.Population_Counter
{
    class Program
    {
        static void Main()
        {
            var populationCounter = new Dictionary<string, Dictionary<string, long>>();

            var line = Console.ReadLine();
            while (line != "report")
            {
                var tokens = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var city = tokens[0];
                var country = tokens[1];
                var population = long.Parse(tokens[2]);
                var cityPopulation = new Dictionary<string, long>();
                if (!populationCounter.ContainsKey(country))
                {
                    cityPopulation[city] = population;
                    populationCounter[country] = cityPopulation;
                }
                else
                {
                    cityPopulation = populationCounter[country];
                    if (cityPopulation.ContainsKey(city))
                        cityPopulation[city] += population;
                    else
                        cityPopulation.Add(city, population);
                    populationCounter[country] = cityPopulation;
                }
                line = Console.ReadLine();
            }
            foreach (var state in populationCounter.OrderByDescending(x => x.Value.Sum(y => y.Value)))
            {
                List<long> sumOfTowns = state.Value.Select(x => x.Value).ToList();
                Console.WriteLine($"{state.Key} (total population: {sumOfTowns.Sum()})");
                Console.Write($"=>{string.Join("=>", state.Value.OrderByDescending(x => x.Value).Select(x => $"{x.Key}: {x.Value}\r\n"))}");
            }
        }
    }
}