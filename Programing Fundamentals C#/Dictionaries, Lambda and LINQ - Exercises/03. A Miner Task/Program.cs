using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.A_Miner_Task
{
    class Program
    {
        static void Main()
        {
            var resources = new Dictionary<string, int>();
            int cnt = 1;
            string resource = String.Empty;
            while (true)
            {
                var command = Console.ReadLine();
                if (command == "stop") break;
                if (cnt % 2 == 1)
                {
                    resource = command;
                }
                else
                {
                    if (!resources.ContainsKey(resource))
                    {
                        resources[resource] = int.Parse(command);
                    }
                    else
                    {
                        resources[resource] += int.Parse(command);
                    }
                    
                }
                cnt++; 
            }
            foreach (var res in resources)
            {
                Console.WriteLine($"{res.Key} -> {res.Value}");
            }
        }
    }
}