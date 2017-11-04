using System;
using System.Linq;
using System.Collections.Generic;

namespace _04.Hornet_Armada
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, Dictionary<string, long>> legionSoldiers = new Dictionary<string, Dictionary<string, long>>();
            Dictionary<string, long> legionActivity = new Dictionary<string, long>();

            long n = long.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var inputArgs = Console.ReadLine().Split(new string[] { " = ", " -> ", ":" }, StringSplitOptions.RemoveEmptyEntries);
                long activity = long.Parse(inputArgs[0]);
                string legion = inputArgs[1];
                string soldier = inputArgs[2];
                long count = long.Parse(inputArgs[3]);

                if (!legionActivity.ContainsKey(legion))
                {
                    legionActivity.Add(legion, activity);
                }
                else
                {
                    if (activity > legionActivity[legion])
                    {
                        legionActivity[legion] = activity;
                    }
                }

                if (!legionSoldiers.ContainsKey(legion))
                {
                    legionSoldiers.Add(legion, new Dictionary<string, long>());
                    legionSoldiers[legion].Add(soldier, count);
                }
                else
                {
                    if (!legionSoldiers[legion].ContainsKey(soldier))
                    {
                        legionSoldiers[legion].Add(soldier, count);
                    }
                    else
                    {
                        legionSoldiers[legion][soldier] += count;
                    }
                }
            }
            var printArgs = Console.ReadLine().Split('\\');
            if (printArgs.Length > 1)
            {
                long activity = long.Parse(printArgs[0]);
                string soldier = printArgs[1];
                foreach (var legion in legionSoldiers
                    .Where(legion => legion.Value.ContainsKey(soldier))
                    .Where(legion => legionActivity[legion.Key] < activity)
                    .OrderByDescending(legion => legion.Value[soldier]))
                {
                    Console.WriteLine($"{legion.Key} -> {legion.Value[soldier]}");
                }
            }
            else
            {
                var soldier = printArgs[0];
                foreach (var legion in legionActivity
                    .Where(legion => legionSoldiers[legion.Key].ContainsKey(soldier))
                    .OrderByDescending(legion => legion.Value))
                {
                    Console.WriteLine($"{legionActivity[legion.Key]} : {legion.Key}");
                }
            }
        }
    }
}