using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.Immune_System
{
    class Program
    {
        static void Main()
        {
            var virusess = new List<string>();
            int initialHealth = int.Parse(Console.ReadLine());
            int startHealth = initialHealth;
            string virus = Console.ReadLine();
            while (virus != "end")
            {
                int virusStrength = CalculatevirusStrength(virus);
                int virusTime = virusStrength * virus.Length;
                if (virusess.Contains(virus))
                {
                    virusTime = (int) (virusTime / 3.0);
                }
                else
                {
                    virusess.Add(virus);
                }
                Console.WriteLine($"Virus {virus}: {virusStrength} => {virusTime} seconds");
                initialHealth -= virusTime;
                if (initialHealth <= 0)
                {
                    Console.WriteLine("Immune System Defeated.");
                    return;
                }
                else
                {
                    Console.WriteLine($"{virus} defeated in {CalculatevirusDefeatSeconds(virusTime)}");
                    Console.WriteLine($"Remaining health: {initialHealth}");
                }               
                initialHealth = Math.Min(startHealth, (int)(initialHealth * 1.20));
                virus = Console.ReadLine();
            }
            Console.WriteLine("Final Health: {0}", initialHealth);
        }

        private static string CalculatevirusDefeatSeconds(int virusTime)
        {
            return virusTime / 60 + "m " + virusTime % 60 + "s.";
        }

        private static int CalculatevirusStrength(string viruses)
        {
            int virusStrength = 0;
            for (int i = 0; i < viruses.Length; i++)
            {
                virusStrength += viruses[i];
            }
            return (int) (virusStrength / 3.0);
        }
    }
}