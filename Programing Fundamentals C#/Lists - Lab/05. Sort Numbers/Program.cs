using System;
using System.Linq;
using System.Collections.Generic;

namespace _05.Sort_Numbers
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .ToList();
            numbers.Sort();
            Console.WriteLine(String.Join(" <= ", numbers));
        }
    }
}