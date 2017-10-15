using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.Phonebook
{
    class Program
    {
        static void Main()
        {
            var phonebook = new Dictionary<string, string>();
            while (true)
            {
                var contact = Console.ReadLine()
             .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                
                if (contact[0] == "END") break;
                switch (contact[0])
                {
                    case "A":                        
                            phonebook[contact[1]] = contact[2];                        
                        break;
                    case "S":
                        if (phonebook.ContainsKey(contact[1]))
                        {
                            Console.WriteLine($"{contact[1]} -> {phonebook[contact[1]]}");
                        }
                        else
                        {
                            Console.WriteLine($"Contact {contact[1]} does not exist.");
                        }
                        break;
                }
            }                   
        }
    }
}