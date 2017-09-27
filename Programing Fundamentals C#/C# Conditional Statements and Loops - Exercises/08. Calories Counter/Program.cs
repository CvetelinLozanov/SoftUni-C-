using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Calories_Counter
{

    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            string products;
            var calories = 0.0;
            for (int i = 0; i < n; i++)
            {
                products = Console.ReadLine().ToLower();
                if (products == "cheese")
                {
                    calories += 500;
                }
                else if (products == "tomato sauce")
                {
                    calories += 150;
                }
                else if (products == "salami")
                {
                    calories += 600;
                }
                else if (products == "pepper")
                {
                    calories += 50;
                }
            }
            Console.WriteLine($"Total calories: {calories}");
        }
    }

}