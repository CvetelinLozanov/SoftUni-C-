using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            var budget = double.Parse(Console.ReadLine());
            var neededItems = int.Parse(Console.ReadLine());
            string item;
            double price;
            int count;
            var sumPrice = 0.0;
            for (int i = 1; i <= neededItems; i++)
            {
                item = Console.ReadLine();
                price = double.Parse(Console.ReadLine());
                count = int.Parse(Console.ReadLine());
                if (count > 1)
                {
                    item += "s";
                    Console.WriteLine($"Adding {count} {item} to cart.");
                }
                else
                {
                    Console.WriteLine($"Adding {count} {item} to cart.");
                }
                sumPrice += price * count;
            }
            if (budget >= sumPrice)
            {
                Console.WriteLine("Subtotal: ${0:f2}", sumPrice);
                Console.WriteLine("Money left: ${0:f2}", budget - sumPrice);
            }
            else
            {
                Console.WriteLine("Subtotal: ${0:f2}", sumPrice);
                Console.WriteLine("Not enough. We need ${0:f2} more.", sumPrice - budget);
            }
        }
    }
}