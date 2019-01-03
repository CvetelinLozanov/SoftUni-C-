using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            var people = new List<KeyValuePair<string, int>>();

            for (int i = 0; i < peopleCount; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name = input[0];
                int age = int.Parse(input[1]);

                people.Add(new KeyValuePair<string, int>(name, age));
            }

            string filter = Console.ReadLine();
            int filterAge = int.Parse(Console.ReadLine());

            string[] printPattern = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            people
                .Where(p => filter == "younger" ? p.Value < filterAge : p.Value >= filterAge)
                .ToList()
                .ForEach(p => Printer(p, printPattern));
        }

        private static void Printer(KeyValuePair<string, int> p, string[] printPattern)
        {
            if (printPattern.Length == 2)
            {
                Console.WriteLine(printPattern[0] == "name"?
                   $"{p.Key} - {p.Value}":
                   $"{p.Value} - {p.Key}");
            }
            else
            {
                Console.WriteLine(printPattern[0] == "name"?
                    $"{p.Key}":
                    $"{p.Value}");
            }
        }
    }
}