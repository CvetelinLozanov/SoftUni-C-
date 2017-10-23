using System;
using System.Linq;
using System.Collections.Generic;

namespace _04.Pokemon_Evolution
{
    class Program
    {
        static void Main()
        {
            string command = Console.ReadLine();
            var pokemons = new Dictionary<string, List<Evolution>>();
            while (command != "wubbalubbadubdub")
            {
                var tokens = command.Split(" ->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                string pokemonName = tokens[0];
                if (tokens.Length > 1)
                {
                    Evolution evolution = new Evolution
                    {
                        EvolutionType = tokens[1],
                        EvolutionIndex = long.Parse(tokens[2]),
                    };

                    if (!pokemons.ContainsKey(pokemonName))
                    {
                        pokemons[pokemonName] = new List<Evolution>();
                    }
                    pokemons[pokemonName].Add(evolution);
                }
                else
                {
                    if (pokemons.ContainsKey(pokemonName))
                    {
                        Console.WriteLine($"# {pokemonName}");

                        foreach (var pokemon in pokemons[pokemonName])
                        {
                            Console.WriteLine($"{pokemon.EvolutionType} <-> {pokemon.EvolutionIndex}");
                        }
                    }
                }
                command = Console.ReadLine();
            }
            foreach (var pokemon in pokemons)
            {
                Console.WriteLine($"# {pokemon.Key}");
                foreach (var poke in pokemon.Value.OrderByDescending(p => p.EvolutionIndex))
                {
                    Console.WriteLine($"{poke.EvolutionType} <-> {poke.EvolutionIndex}");
                }
            }            
        }         
    }
    class Evolution
    {
        public string EvolutionType { get; set; }

        public long EvolutionIndex { get; set; }
    }
}
