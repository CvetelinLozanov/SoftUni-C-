using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Restaurant_Discount
{

    class Program
    {
        static void Main(string[] args)
        {
            var groupSize = int.Parse(Console.ReadLine());
            var package = Console.ReadLine();
            var price = 0.0;
            if (groupSize <= 50)
            {
                price = 2500.0;
                if (package == "Normal")
                {
                    price += 500.0;
                    price -= price * 0.05;
                }
                else if (package == "Gold")
                {
                    price += 750.0;
                    price -= price * 0.10;
                }
                else
                {
                    price += 1000.0;
                    price -= price * 0.15;
                }
                Console.WriteLine($"We can offer you the Small Hall");
                Console.WriteLine($"The price per person is {price / groupSize:F2}$");
            }
            else if (groupSize <= 100)
            {
                price = 5000.0;
                if (package == "Normal")
                {
                    price += 500.0;
                    price -= price * 0.05;
                }
                else if (package == "Gold")
                {
                    price += 750.0;
                    price -= price * 0.10;
                }
                else
                {
                    price += 1000.0;
                    price -= price * 0.15;
                }
                Console.WriteLine($"We can offer you the Terrace");
                Console.WriteLine($"The price per person is {price / groupSize:F2}$");
            }
            else if (groupSize <= 120)
            {
                price = 7500.0;
                if (package == "Normal")
                {
                    price += 500.0;
                    price -= price * 0.05;
                }
                else if (package == "Gold")
                {
                    price += 750.0;
                    price -= price * 0.10;
                }
                else
                {
                    price += 1000.0;
                    price -= price * 0.15;
                }
                Console.WriteLine($"We can offer you the Great Hall");
                Console.WriteLine($"The price per person is {price / groupSize:F2}$");
            }
            else
            {
                Console.WriteLine("We do not have an appropriate hall.");
            }

        }
    }

}