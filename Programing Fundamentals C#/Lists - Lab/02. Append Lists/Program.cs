using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Append_Lists
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            input.Reverse();
            var result = new List<string>();
            foreach (var item in input)
            {
                var nums = item.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList();
                foreach (var num in nums)
                {
                    result.Add(num);
                }
            }
            Console.WriteLine(String.Join(" ", result));
        }
    }
}