using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace _02HornetComm
{
    class Program
    {
        static void Main()
        {
            string messageRegex = @"^([\d]+) <-> ([A-Za-z0-9]+)$";
            string broadcastRegex = @"^([\D]+) <-> ([A-Za-z0-9]+)$";

            Regex message = new Regex(messageRegex);
            Regex broadcast = new Regex(broadcastRegex);

            List<string> messages = new List<string>();
            List<string> broadcasts = new List<string>();
            string input;
            while ((input = Console.ReadLine()) != "Hornet is Green")
            {
                if (message.IsMatch(input))
                {
                    var tokens = input.Split(new string[] { " <-> " }, StringSplitOptions.RemoveEmptyEntries);
                    messages.Add($"{string.Join("", tokens[0].ToCharArray().Reverse())} -> {tokens[1]}");
                }
                if (broadcast.IsMatch(input))
                {
                    var tokens = input.Split(new string[] { " <-> " }, StringSplitOptions.RemoveEmptyEntries);
                    StringBuilder sb = new StringBuilder();
                    foreach (var letter in tokens[1].ToCharArray())
                    {
                        if (Char.IsUpper(letter))
                        {
                            sb.Append(Char.ToLower(letter));
                            continue;
                        }
                        if (Char.IsLower(letter))
                        {
                            sb.Append(Char.ToUpper(letter));
                            continue;
                        }
                        sb.Append(letter);
                    }
                    broadcasts.Add($"{sb} -> {tokens[0]}");
                }
            }
            Console.WriteLine("Broadcasts:");
            PrintCurrent(broadcasts);
            Console.WriteLine("Messages:");
            PrintCurrent(messages);
        }

        private static void PrintCurrent(List<string> current)
        {
            if (current.Count == 0)
            {
                Console.WriteLine("None");
            }
            foreach (var item in current)
            {
                Console.WriteLine(item);
            }
        }
    }
}