using System;
using System.Linq;
using System.Collections.Generic;

namespace _04.Supermarket_Database
{
    class Program
    {
        static void Main()
        {
            var productsArgs = new Dictionary<string, List<decimal>>();
            string command = Console.ReadLine();
            while (command != "stocked")
            {
                string[] productsInfo = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string product = productsInfo[0];
                decimal price = decimal.Parse(productsInfo[1]);
                decimal quantity = decimal.Parse(productsInfo[2]);
                if (!productsArgs.ContainsKey(product))
                {
                    productsArgs.Add(product, new List<decimal>());
                    productsArgs[product].Add(price);
                    productsArgs[product].Add(quantity);
                }
                else
                {
                    var oldList = productsArgs[product];
                    productsArgs[product][0] = price;
                    productsArgs[product][1] += quantity;
                }
                command = Console.ReadLine();
            }
            decimal totalPrice = 0m;
            foreach (var product in productsArgs)
            {
                decimal productTotalPrice = product.Value[0] * product.Value[1];
                totalPrice += productTotalPrice;
                Console.WriteLine($"{product.Key}: ${product.Value[0]} * {product.Value[1]} = ${productTotalPrice}");
            }
            Console.WriteLine("------------------------------");
            Console.WriteLine($"Grand Total: ${totalPrice}");
        }
    }
}