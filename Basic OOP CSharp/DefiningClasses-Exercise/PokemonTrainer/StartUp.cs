using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class StartUp
    {
        public static List<Trainer> trainers; 
        public static Pokemon pokemon;
        public static void Main(string[] args)
        {
            trainers = new List<Trainer>();
       
            string command = Console.ReadLine();

            while (command != "Tournament")
            {               
                string[] commandArgs = command
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string trainerName = commandArgs[0];
                string pokemonName = commandArgs[1];
                string pokemonElement = commandArgs[2];
                int pokemonHealth = int.Parse(commandArgs[3]);                
                pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                Trainer trainer = GetTrainer(trainerName);
                command = Console.ReadLine();
            }

            command = Console.ReadLine();
            while (command != "End")
            {
                switch (command)
                {
                    case "Fire":
                        CheckCommand(command);
                        break;
                    case "Electricity":
                        CheckCommand(command);
                        break;
                    case "Water":
                        CheckCommand(command);
                        break;
                }
                command = Console.ReadLine();
            }

            foreach (var trainer in trainers.OrderByDescending(x => x.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }

        }

        private static void CheckCommand(string command)
        {
            foreach (var trainer in trainers)
            {
                if (trainer.Pokemons.Any(x => x.Element == command))
                {
                    trainer.NumberOfBadges++;                   
                }
                else
                {
                    SearchForPokemonHealth(command, trainer);                   
                }
            }
        }

        private static void SearchForPokemonHealth(string command, Trainer trainer)
        {
            List<Pokemon> pokemons = trainer.Pokemons;
            foreach (var pokemon in pokemons)
            {
                pokemon.Health -= 10;
                CheckPokemonHealth(pokemon, trainer);
                if (pokemons.Count == 0)
                {
                    break;
                }
            }
            
        }

        private static void CheckPokemonHealth(Pokemon pokemon, Trainer trainer)
        {
            if (pokemon.Health <= 0)
            {
                trainer.Pokemons.Remove(pokemon);                
            }
        }

        private static Trainer GetTrainer(string trainerName)
        {
            Trainer trainer = trainers.FirstOrDefault(x => x.Name == trainerName);

            if (trainer == null)
            {
                trainer = new Trainer();
                trainer.Name = trainerName;
                trainer.Pokemons.Add(pokemon);
                trainers.Add(trainer);
            }
            else
            {
                trainer.Pokemons.Add(pokemon);                
            }
           
            return trainer;
        }
    }
}
