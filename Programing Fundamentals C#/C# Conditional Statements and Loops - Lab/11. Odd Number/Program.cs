using System;

namespace _11.Odd_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = Math.Abs(int.Parse(Console.ReadLine()));

            while (n % 2 != 1)
            {
                Console.WriteLine("Please write an odd number.");
                n = Math.Abs(int.Parse(Console.ReadLine()));
            }
            Console.WriteLine("The number is: {0}", n);
        }
    }
}