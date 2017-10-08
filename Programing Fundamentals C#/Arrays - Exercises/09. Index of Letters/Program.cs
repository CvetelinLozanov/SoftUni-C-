using System;

namespace _09.Index_of_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            string letters = Console.ReadLine();
            for (int i = 0; i < letters.Length; i++)
            {
                Console.WriteLine($"{letters[i]} -> {letters[i] - 97}");
            }
        }
    }
}