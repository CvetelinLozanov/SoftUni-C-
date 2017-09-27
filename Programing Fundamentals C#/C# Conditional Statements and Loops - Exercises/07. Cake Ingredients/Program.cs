using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _07.Cake_Ingredients
{
    class Program
    {
        static void Main(string[] args)
        {
            var ingrediets = Console.ReadLine();
            var cnt = 0;
            while (ingrediets != "Bake!")
            {
                cnt++;
                Console.WriteLine($"Adding ingredient {ingrediets}.");
                ingrediets = Console.ReadLine();
            }

            Console.WriteLine($"Preparing cake with {cnt} ingredients.");
        }
    }

}