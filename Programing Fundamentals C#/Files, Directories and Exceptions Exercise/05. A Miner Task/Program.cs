using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace _5.A_Miner_Task
{
    class Program
    {
        static void Main()
        {
            string[] input = File.ReadAllLines("input.txt");
            int cnt = 0;
            string resource = String.Empty;
            var resourcesAndQuantity = new Dictionary<string, int>();
            File.Delete("output.txt"); 
            while (true)
            {
                string command = input[cnt];
                if (command == "stop") break;
                if (cnt % 2 == 0)
                {
                    resource = command;
                }
                else
                {
                    if (!resourcesAndQuantity.ContainsKey(resource))
                    {
                        resourcesAndQuantity.Add(resource, int.Parse(command));
                    }
                    else
                    {
                        resourcesAndQuantity[resource] += int.Parse(command);
                    }
                }
                cnt++;
            }
            foreach (var resourc in resourcesAndQuantity)
            {
               File.AppendAllText("output.txt", $"{resourc.Key} -> {resourc.Value}{Environment.NewLine}");
            }
        }
    }
}