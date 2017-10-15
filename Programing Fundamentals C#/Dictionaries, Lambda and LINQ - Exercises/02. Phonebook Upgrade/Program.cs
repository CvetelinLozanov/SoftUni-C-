using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.Phonebook_Upgrade
{
    class Program
    {
        static void Main()
        {
            var phonebook = new SortedDictionary<string, string>();
            while (true)
            {
                var contacts = Console.ReadLine()
             .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (contacts[0] == "END") break;
                switch (contacts[0])
                {
                    case "A":
                        phonebook[contacts[1]] = contacts[2];
                        break;
                    case "S":
                        PrintOneContact(phonebook, contacts);
                        break;

                    case "ListAll":
                        PrintAllSorted(phonebook);
                        break;
                }
            }
        }

        private static void PrintAllSorted(SortedDictionary<string, string> phonebook)
        {
            foreach (var contact in phonebook)
            {
                Console.WriteLine($"{contact.Key} -> {contact.Value}");
            }
        }

        private static void PrintOneContact(SortedDictionary<string, string> phonebook, string[] contacts)
        {
            if (phonebook.ContainsKey(contacts[1]))
            {
                Console.WriteLine($"{contacts[1]} -> {phonebook[contacts[1]]}");
            }
            else
            {
                Console.WriteLine($"Contact {contacts[1]} does not exist.");
            }
        }
    }
}