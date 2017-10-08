using System;
using System.Linq;

namespace _01.Array_Statistics
{
    class Program
    {
        static void Main()
        {
            long[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();
            long minValue = long.MaxValue;
            long maxValue = long.MinValue;
            long sum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > maxValue)
                {
                    maxValue = numbers[i];
                }
                if (numbers[i] < minValue)
                {
                    minValue = numbers[i];
                }
                sum += numbers[i];
            }
            Console.WriteLine($"Min = {minValue}");
            Console.WriteLine($"Max = {maxValue}");
            Console.WriteLine($"Sum = {sum}");
            Console.WriteLine($"Average = {(double)sum / numbers.Length}");
        }
    }
}