using System;
using System.Linq;

namespace _06.Heists
{
    class Program
    {
        static void Main()
        {
            int[] prices = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            long priceForJewels = prices[0];
            long priceForGold = prices[1];
            long heistPrice = 0;
            long jewelsPrice = 0;
            long goldPrice = 0;
            string[] command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            while (command[0] != "Jail")
            {
                string loot = command[0];                
                heistPrice += long.Parse(command[1]);
                for (int i = 0; i < loot.Length; i++)
                {
                    if (loot[i] == '$')
                    {
                        goldPrice += priceForGold;
                    }
                    if (loot[i] == '%')
                    {
                        jewelsPrice += priceForJewels;
                    }
                }
                command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
            long sumPrice = goldPrice + jewelsPrice;
            if (sumPrice >= heistPrice)
            {
                Console.WriteLine($"Heists will continue. Total earnings: {sumPrice - heistPrice}.");
            }
            else
            {
                Console.WriteLine($"Have to find another job. Lost: {heistPrice - sumPrice}.");
            }
        }
    }
}