using System;
using System.Linq;

namespace _08.Upgraded_Matcher
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var quantityInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            var prices = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToArray();

            var quantity = new long[products.Length];
            for (int i = 0; i < quantityInput.Length; i++)
            {
                quantity[i] = quantityInput[i];
            }
            while (true)
            {
                var element = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


                if (element[0] == "done")
                {
                    break;
                }

                long neededQuantity = long.Parse(element[1]);
                int indexElement = Array.IndexOf(products, element[0]);
                if (neededQuantity <= quantity[indexElement])
                {
                    decimal totalPrice = neededQuantity * prices[indexElement];
                    Console.WriteLine($"{products[indexElement]} x {neededQuantity} costs {totalPrice:F2}");
                    quantity[indexElement] = quantity[indexElement] - neededQuantity;
                }
                else
                {
                    Console.WriteLine($"We do not have enough {products[indexElement]}");
                }
            }
        }
    }
}