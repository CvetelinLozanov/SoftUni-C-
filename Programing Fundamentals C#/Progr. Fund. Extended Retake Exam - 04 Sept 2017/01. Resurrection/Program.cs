using System;

namespace _01.Resurrection
{
    class Program
    {
        static void Main()
        {
            int numOfPhoenixes = int.Parse(Console.ReadLine());
            for (int i = 0; i < numOfPhoenixes; i++)
            {
                int totalLength = int.Parse(Console.ReadLine());
                decimal totalWidth = decimal.Parse(Console.ReadLine());
                int totalWingLength = int.Parse(Console.ReadLine());
                decimal totalYears = (decimal)Math.Pow(totalLength, 2) * (totalWidth + 2 * totalWingLength);
                Console.WriteLine(totalYears);
            }
        }
    }
}