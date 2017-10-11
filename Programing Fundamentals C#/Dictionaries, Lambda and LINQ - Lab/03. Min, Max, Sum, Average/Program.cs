using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.Min__Max__Sum__Average
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var nums = new int[n];

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                nums[i] = number;
            }

            Console.WriteLine($"Sum = {nums.Sum()}");
            Console.WriteLine($"Min = {nums.Min()}");
            Console.WriteLine($"Max = {nums.Max()}");
            Console.WriteLine($"Average = {nums.Average()}");
        }
    }
}