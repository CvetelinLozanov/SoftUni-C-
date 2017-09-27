using System;

namespace _10.Sum_of_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            int sumOfChars = 0;
            for (int i = 1; i <= n; i++)
            {
                var letters = char.Parse(Console.ReadLine());
                sumOfChars += letters;
            }
            Console.WriteLine("The sum equals: " + sumOfChars);
        }
    }
}