using System;
using System.Linq;
using System.Collections.Generic;

namespace _04.Largest_3_Numbers
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderByDescending(a => a)
                .Take(3)
                .ToArray();
            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}