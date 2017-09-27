using System;

namespace _08.House_Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            var num1 = int.Parse(Console.ReadLine());
            var num2 = int.Parse(Console.ReadLine());
            long totalPrice = num1 > num2 ? ((long)num1 * 10 + (long)num2 * 4) : ((long)num1 * 4 + (long)num2 * 10);
            Console.WriteLine(totalPrice);
        }
    }
}