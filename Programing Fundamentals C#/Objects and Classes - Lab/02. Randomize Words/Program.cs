using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.Randomize_Words
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Random rnd = new Random();
            for (int i = 0; i < input.Length; i++)
            {
                int index = rnd.Next(0, input.Length);
                string old = input[index];
                int newIndex = rnd.Next(0, input.Length);
                input[index] = input[newIndex];               
                input[newIndex] = old;
            }
            foreach (var word in input)
            {
                Console.WriteLine(word);
            }
        }
    }
}