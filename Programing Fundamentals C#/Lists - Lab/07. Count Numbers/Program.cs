using System;
using System.Linq;
using System.Collections.Generic;

namespace _07.Count_Numbers
{
    class Program
    {
        static void Main()
        {

            var numbers = new Dictionary<int, int>();
            var nums = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            for (int i = 0; i < nums.Count; i++)
            {
                if (!numbers.ContainsKey(nums[i]))
                {
                    numbers[nums[i]] = 1;
                }
                else
                {
                    numbers[nums[i]]++;
                }
            }
            numbers = numbers.OrderBy(a => a.Key)
              .ToDictionary(x => x.Key, x => x.Value);
            ;
            foreach (var num in numbers)
            {
                Console.WriteLine($"{num.Key} => {num.Value}");
            }
        }
    }
}