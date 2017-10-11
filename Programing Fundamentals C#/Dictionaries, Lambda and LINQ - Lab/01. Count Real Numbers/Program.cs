using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.Count_Real_Numbers
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            var sortedNums = new SortedDictionary<double, int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (!sortedNums.ContainsKey(numbers[i]))
                {
                    sortedNums[numbers[i]] = 1;
                }
                else
                {
                    sortedNums[numbers[i]]++;
                }
            }
            foreach (var num in sortedNums)
            {
                Console.WriteLine($"{num.Key} -> {num.Value}");
            }
        }
    }
}