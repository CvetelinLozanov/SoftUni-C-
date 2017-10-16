using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.Odd_Filter
{
    class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(n => n % 2 == 0)                
                .ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > Math.Ceiling(numbers.Average()))
                {
                    numbers[i]++;
                }
                else
                {
                    numbers[i]--;
                }
            }
            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}