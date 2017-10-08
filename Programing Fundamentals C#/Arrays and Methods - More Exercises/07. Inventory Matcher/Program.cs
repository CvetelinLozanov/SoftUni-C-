using System;
using System.Linq;

namespace _07.Inventory_Matcher
{
    class Program
    {
        static void Main()
        {
            string[] products = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            long[] quantity = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();
            decimal[] priceForProducts = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .ToArray();
            string product = Console.ReadLine();
            while (product != "done")
            {
                for (int i = 0; i < products.Length; i++)
                {
                    if (product == products[i])
                    {
                        Console.WriteLine($"{product} costs: {priceForProducts[i]}; Available quantity: {quantity[i]}");
                    }
                }
                product = Console.ReadLine();
            }
        }
    }
}