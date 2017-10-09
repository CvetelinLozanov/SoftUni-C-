using System;
using System.Linq;
using System.Collections.Generic;

namespace _06.Square_Numbers
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();
            var squareNums = new List<double>();
            foreach (var num in numbers)
            {
                if (Math.Sqrt(num) == (int)Math.Sqrt(num))
                {
                    squareNums.Add(num);
                }
            }
            squareNums.Sort((a, b) => b.CompareTo(a));
            Console.WriteLine(String.Join(" ", squareNums));
        }
    }
}