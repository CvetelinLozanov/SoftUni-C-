using System;

namespace _09.Make_a_Word
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            string word = string.Empty;
            for (int i = 1; i <= n; i++)
            {
                var letters = Console.ReadLine();
                word += letters;
            }
            Console.WriteLine("The word is: " + word);
        }
    }
}