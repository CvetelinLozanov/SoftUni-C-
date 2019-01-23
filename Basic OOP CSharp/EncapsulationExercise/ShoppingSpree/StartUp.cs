using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    class StartUp
    {
        public static List<Person> people;
        public static List<Product> products;
        static void Main(string[] args)
        {
            people = new List<Person>();
            products = new List<Product>();
            string[] inputPeople = Console.ReadLine()
                .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            string[] inputProducts = Console.ReadLine()
                .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < inputPeople.Length; i++)
            {
                string[] personArgs = inputPeople[i]
                    .Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                string name = personArgs[0];
                decimal money = decimal.Parse(personArgs[1]);
                Person person = new Person(name, money);
                people.Add(person);
            }
            for (int i = 0; i < inputProducts.Length; i++)
            {
                string[] productArgs = inputProducts[i]
                    .Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                string productName = productArgs[0];
                decimal productPrice = decimal.Parse(productArgs[1]);
                Product product = new Product(productName, productPrice);
                products.Add(product);
            }

            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] commandArgs = command
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string customerName = commandArgs[0];
                string productName = commandArgs[1];
                Product product = GetProduct(productName);
                foreach (var person in people)
                {
                    if (person.Name == customerName)
                    {
                        person.CanPersonBuyTheProduct(product);
                    }
                }
                command = Console.ReadLine();
            }


            PrintResult();
        }

        private static void PrintResult()
        {
            foreach (var person in people)
            {
               
                Console.WriteLine(person.ToString());
            }
        }

        private static Product GetProduct(string productName)
        {
            return products.FirstOrDefault(p => p.Name == productName);
        }
    }
}
