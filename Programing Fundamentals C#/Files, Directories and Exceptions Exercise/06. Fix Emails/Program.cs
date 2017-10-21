using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace _06.Fix_Emails
{
    class Program
    {
        static void Main()
        {
            string[] input = File.ReadAllLines("input.txt");
            var fixedEmails = new Dictionary<string, string>();
            for (int i = 0; i < input.Length; i += 2)
            {
                string name = input[i];
                
                if (name == "stop" || input[i + 1] == "stop")
                {
                    break;
                }
                string eMail = input[i + 1];
                if (eMail.EndsWith(".us") || eMail.EndsWith(".uk"))
                {
                    continue;
                }
                fixedEmails[name] = eMail;
            }
            foreach (var person in fixedEmails)
            {
                File.AppendAllText("output.txt", $"{person.Key} -> {person.Value}{Environment.NewLine}");
            }
        }
    }
}