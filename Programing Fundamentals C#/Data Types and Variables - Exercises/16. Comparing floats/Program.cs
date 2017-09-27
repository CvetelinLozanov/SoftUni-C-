using System;

namespace _16.Comparing_floats
{
    class Program
    {
        static void Main(string[] args)
        {
            var num1 = double.Parse(Console.ReadLine());
            var num2 = double.Parse(Console.ReadLine());
            double difference = Math.Abs(num1 - num2);
            double eps = 0.000001;
            if (difference < eps)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}