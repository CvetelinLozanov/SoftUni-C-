using System;
using System.Linq;
using System.Collections.Generic;

namespace _08.Logs_Aggregator
{
    class Program
    {
        static void Main()
        {
            var dict = new SortedDictionary<string, SortedDictionary<string, long>>();

            int line = int.Parse(Console.ReadLine());
           
            for (int i = 0; i < line; i++)
            {
                string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string ip = input[0];
                string name = input[1];
                long duration = long.Parse(input[2]);
                if (!dict.ContainsKey(name))
                {
                    dict.Add(name, new SortedDictionary<string, long>());                    
                }
                if (!dict[name].ContainsKey(ip))
                {
                    dict[name][ip] = 0;
                }
                dict[name][ip] += duration;
            }
            foreach (var person in dict)
            {
                string name = person.Key;
                var ipDuration = person.Value;

                var ip = ipDuration.Select(a => a.Key).ToArray();
                var totalIpDuration = ipDuration.Sum(a => a.Value);

                Console.WriteLine($"{name}: {totalIpDuration} [{String.Join(", ", ip)}]");
            }
        }
    }
}