using System;

namespace _03.Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            short sum = 255;
            short capacityCopy = sum;
            for (int i = 1; i <= n; i++)
            {
                short litersForTank = short.Parse(Console.ReadLine());
                if (capacityCopy - litersForTank >= 0)
                {
                    capacityCopy -= litersForTank;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }
            Console.WriteLine(sum - capacityCopy);
        }
    }
}