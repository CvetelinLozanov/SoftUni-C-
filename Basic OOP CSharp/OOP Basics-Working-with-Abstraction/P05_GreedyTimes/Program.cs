using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{

    public class Potato
    {
        static void Main(string[] args)
        {
            long bagMaxCapacity = long.Parse(Console.ReadLine());
            string[] safe = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bundle = new Dictionary<string, Dictionary<string, long>>();
            long gold = 0;
            long gems = 0;
            long cash = 0;

            for (int i = 0; i < safe.Length; i += 2)
            {
                string name = safe[i];
                long amount = long.Parse(safe[i + 1]);

                string type = string.Empty;

                if (name.Length == 3)
                {
                    type = "Cash";
                }
                else if (name.ToLower().EndsWith("gem"))
                {
                    type = "Gem";
                }
                else if (name.ToLower() == "gold")
                {
                    type = "Gold";
                }

                if (type == "")
                {
                    continue;
                }
                else if (bagMaxCapacity < bundle.Values.Select(x => x.Values.Sum()).Sum() + amount)
                {
                    continue;
                }

                switch (type)
                {
                    case "Gem":
                        if (!bundle.ContainsKey(type))
                        {
                            if (bundle.ContainsKey("Gold"))
                            {
                                if (amount > bundle["Gold"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bundle[type].Values.Sum() + amount > bundle["Gold"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                    case "Cash":
                        if (!bundle.ContainsKey(type))
                        {
                            if (bundle.ContainsKey("Gem"))
                            {
                                if (amount > bundle["Gem"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bundle[type].Values.Sum() + amount > bundle["Gem"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                }

                if (!bundle.ContainsKey(type))
                {
                    bundle[type] = new Dictionary<string, long>();
                }

                if (!bundle[type].ContainsKey(name))
                {
                    bundle[type][name] = 0;
                }

                bundle[type][name] += amount;
                if (type == "Gold")
                {
                    gold += amount;
                }
                else if (type == "Gem")
                {
                    gems += amount;
                }
                else if (type == "Cash")
                {
                    cash += amount;
                }
            }

            foreach (var x in bundle)
            {
                Console.WriteLine($"<{x.Key}> ${x.Value.Values.Sum()}");
                foreach (var item2 in x.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item2.Key} - {item2.Value}");
                }
            }
        }
    }
}