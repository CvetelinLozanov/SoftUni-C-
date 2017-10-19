using System;
using System.Linq;
using System.Collections.Generic;

namespace _07.Andrey_and_Billiard
{
    class Program
    {
        static void Main()
        {
            int numOfProducts = int.Parse(Console.ReadLine());
            Dictionary<string, decimal> products = TakeProducts(numOfProducts);

            List<Customer> customers = new List<Customer>();
            decimal productPrice = 0m;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of clients") break;
                string[] tokens = input.Split(new char[] { ' ', ',', '-' }, StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                string product = tokens[1];
                decimal quantity = decimal.Parse(tokens[2]);
                if (!products.ContainsKey(product))
                {
                    continue;
                }
                Customer customer = new Customer();
                customer.Name = name;
                customer.BoughtProducts = new Dictionary<string, decimal>();
                customer.BoughtProducts.Add(product, quantity);
                productPrice = products[product];
                if (customers.Any(c => c.Name == name))
                {
                    Customer existingCustomer = customers.First(c => c.Name == name);
                    if (existingCustomer.BoughtProducts.ContainsKey(product))
                    {
                        existingCustomer.BoughtProducts[product] += quantity;
                        existingCustomer.Bill += productPrice * quantity;
                    }
                    else
                    {
                        existingCustomer.BoughtProducts[product] = quantity;
                        existingCustomer.Bill += productPrice * quantity;
                    }
                }
                else
                {
                    customer.Bill = productPrice * quantity;
                    customers.Add(customer);
                }


            }
            decimal totalBill = 0m;
            foreach (var customer in customers.OrderBy(c => c.Name).ThenBy(c => c.Bill))
            {
                Console.WriteLine(customer.Name);
                foreach (var product in customer.BoughtProducts)
                {
                    Console.WriteLine($"-- {product.Key} - {product.Value}");
                }
                totalBill += customer.Bill;
                Console.WriteLine($"Bill: {customer.Bill:F2}");
            }
            Console.WriteLine($"Total bill: {totalBill:F2}");
        }

        private static Dictionary<string, decimal> TakeProducts(int numOfProducts)
        {
            Dictionary<string, decimal> products = new Dictionary<string, decimal>();
            for (int i = 0; i < numOfProducts; i++)
            {
                string[] prods = Console.ReadLine().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                string product = prods[0];
                decimal priceForProduct = decimal.Parse(prods[1]);
                if (!products.ContainsKey(product))
                {
                    products.Add(product, priceForProduct);
                }
                else
                {
                    products[product] = priceForProduct;
                }
            }
            return products;
        }
    }
    public class Customer
    {
        public string Name { get; set; }
        public Dictionary<string, decimal> BoughtProducts { get; set; }
        public decimal Bill { get; set; }
    }
}