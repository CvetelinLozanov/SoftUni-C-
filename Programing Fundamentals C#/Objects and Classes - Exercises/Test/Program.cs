using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.AndreyAndBilliard
{
    public class Costumer
    {
        public string Name { get; set; }

        public Dictionary<string, decimal> Order { get; set; }

        public decimal Bill { get; set; }

    }

    public class AndreyAndBilliard
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var shopList = new Dictionary<string, decimal>();

            for (int i = 0; i < n; i++)
            {
                var productData = Console.ReadLine().Split('-').ToList();
                var productName = productData[0];
                var productPrice = decimal.Parse(productData[1]);

                if (!shopList.ContainsKey(productName))
                {
                    shopList.Add(productName, productPrice);
                }
                else
                {
                    shopList[productName] = productPrice;
                }

            }

            var input = Console.ReadLine();

            var costumers = new List<Costumer>();

            while (input != "end of clients")
            {
                var inputTokens = input.Split(new[] { '-', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                var costumerName = inputTokens[0];
                var productName = inputTokens[1];
                var productPrice = decimal.Parse(inputTokens[2]);

                if (!shopList.ContainsKey(productName))
                {
                    input = Console.ReadLine();
                    continue;
                }

                var costumer = new Costumer();
                costumer.Name = costumerName;
                costumer.Order = new Dictionary<string, decimal>();
                costumer.Order.Add(productName, productPrice);
                costumers.Add(costumer);

                input = Console.ReadLine();
            }

            foreach (var customer in costumers)
            {
                foreach (var item in customer.Order)
                {
                    foreach (var product in shopList)
                    {
                        if (item.Key == product.Key)
                        {
                            customer.Bill += product.Value * item.Value;
                        }
                    }
                }
            }

            costumers = costumers
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Bill)
                .ToList();

            foreach (var costumer in costumers)
            {
                Console.WriteLine($"{costumer.Name}");

                foreach (var product in costumer.Order)
                {
                    Console.WriteLine($"-- {product.Key} - {product.Value}");
                }
                Console.WriteLine($"Bill: {costumer.Bill:F2}");
            }
            Console.WriteLine("Total bill: {0:F2}", costumers.Sum(x => x.Bill));
        }
    }
}