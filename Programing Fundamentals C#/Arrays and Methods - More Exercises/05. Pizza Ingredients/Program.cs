using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Pizza_Ingredients
{
    class Program
    {
        static void Main()
        {
            string[] ingredients = Console.ReadLine()
                  .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int ingredientsCounter = 0;
            int ingredientLenght = int.Parse(Console.ReadLine());
            var listWithGradients = new List<string>(); 
            for (int i = 0; i < ingredients.Length; i++)
            {
                if (ingredients[i].Length == ingredientLenght)
                {
                    ingredientsCounter++;
                    listWithGradients.Add(ingredients[i]);
                    Console.WriteLine($"Adding {ingredients[i]}.");
                    if (ingredientsCounter >= 10)
                    {
                        break;
                    }
                }
            }
            Console.WriteLine($"Made pizza with total of {ingredientsCounter} ingredients.");
            Console.WriteLine($"The ingredients are: {String.Join(", ", listWithGradients)}.");
        }
    }
}