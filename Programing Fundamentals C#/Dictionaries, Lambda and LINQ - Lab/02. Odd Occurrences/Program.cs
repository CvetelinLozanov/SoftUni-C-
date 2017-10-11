using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _02.Odd_Occurrences
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine()
                .ToLower()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var dict = new Dictionary<string, int>();
            foreach (var num in input)
            {
                if (!dict.ContainsKey(num))
                {
                    dict[num] = 1;
                }
                else
                {
                    dict[num]++;
                }
            }
            var result = new List<string>();
            foreach (var word in dict)
            {
                if (word.Value % 2 == 1)
                {
                    result.Add(word.Key);
                }
            }           
            Console.WriteLine(String.Join(", ", result));
        }
    }
}