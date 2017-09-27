using System;

namespace _17.Print_Part_Of_ASCII_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());
            for (int i = n; i <= m; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}