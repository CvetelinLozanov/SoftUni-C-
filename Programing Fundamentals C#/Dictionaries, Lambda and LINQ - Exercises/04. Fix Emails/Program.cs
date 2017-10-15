using System;
using System.Linq;
using System.Collections.Generic;

namespace _04.Fix_Emails
{
    class Program
    {
        static void Main()
        {
            var mailBook = new Dictionary<string, string>();
            while (true)
            {
                string name = Console.ReadLine();
                if (name == "stop") break;
                string email = Console.ReadLine();
                if (email.EndsWith("us") || email.EndsWith("uk"))
                {
                    continue;
                }
                mailBook[name] = email;

            }
            foreach (var nameMail in mailBook)
            {
                Console.WriteLine($"{nameMail.Key} -> {nameMail.Value}");
            }
        }
    }
}