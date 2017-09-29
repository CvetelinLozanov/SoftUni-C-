using System;

namespace _07.Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());
            PrintNumAfterPower(num, power);
        }

        private static void PrintNumAfterPower(double num, int power)
        {
            double result = 1D;
            for (int i = 1; i <= power; i++)
            {
                result *= num;
            }
            Console.WriteLine(result);
        }
    }
}