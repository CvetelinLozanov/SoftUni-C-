using System;

namespace _15.Neighbour_Wars
{

    class Program
    {
        static void Main(string[] args)
        {
            var PeshoDMG = int.Parse(Console.ReadLine());
            var GoshoDMG = int.Parse(Console.ReadLine());
            var PeshoHealth = 100;
            var GoshoHealth = 100;
            int round = 0;


            for (int i = 1; i <= 9999; i++)
            {
                if (i % 2 == 1)
                {
                    GoshoHealth -= PeshoDMG;
                    if (GoshoHealth > 0)
                        Console.WriteLine($"Pesho used Roundhouse kick and reduced Gosho to {GoshoHealth} health.");
                }
                else if (i % 2 == 0)
                {
                    PeshoHealth -= GoshoDMG;
                    if (PeshoHealth > 0)
                        Console.WriteLine($"Gosho used Thunderous fist and reduced Pesho to {PeshoHealth} health.");
                }

                round++;

                if (PeshoHealth <= 0 || GoshoHealth <= 0)
                {
                    if (PeshoHealth > 0)
                    {
                        Console.WriteLine($"Pesho won in {round}th round.");
                    }
                    else if (GoshoHealth > 0)
                    {
                        Console.WriteLine($"Gosho won in {round}th round.");
                    }
                    break;
                }

                if (i % 3 == 0)
                {
                    PeshoHealth += 10;
                    GoshoHealth += 10;
                }
            }

        }
    }

}