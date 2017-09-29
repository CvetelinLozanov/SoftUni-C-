using System;

namespace _03.Printing_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int i = 1; i <= number; i++)
            {
                PrintHeader(i);
                Console.WriteLine();
            }
            for (int i = number - 1; i >= 1; i--)
            {
                PrintFooter(i);
                Console.WriteLine();
            }
        }

        private static void PrintFooter(int i)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write(j + " ");
            }
        }

        private static void PrintHeader(int i)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write(j + " ");
            }
        }
    }
}