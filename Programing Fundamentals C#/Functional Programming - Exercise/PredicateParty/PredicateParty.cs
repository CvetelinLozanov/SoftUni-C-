using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateParty
{
    class PredicateParty
    {
        static void Main(string[] args)
        {

            List<string> guests = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            Action<List<string>> print = p => Console.WriteLine(String.Join(", ", p) + " are going to the party!");
            Predicate<string> predicate;
          
            string input = Console.ReadLine();
            while (input != "Party!")
            {
                string[] commandArgs = input
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string command = commandArgs[0];
                string predicateName = commandArgs[1];
                string value = commandArgs[2];

                predicate = GetPredicate(predicateName, value);

                if (command == "Remove")
                {
                    guests.RemoveAll(predicate);
                }
                else if (command == "Double")
                {
                    var newGuest = guests.FindAll(predicate);
                    foreach (var guest in newGuest)
                    {
                        int indexOfCurrentGuest = guests.IndexOf(guest);

                        guests.Insert(indexOfCurrentGuest + 1, guest);
                    }
                }

                input = Console.ReadLine();
            }

            if (guests.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                print(guests);
            }
        
        }

        private static Predicate<string> GetPredicate(string predicateName, string value)
        {
            if (predicateName == "StartsWith")
            {
                return p => p.StartsWith(value);
            }
            else if (predicateName == "StartsWith")
            {
                return p => p.EndsWith(value);
            }
            else if (predicateName == "Length")
            {
                return p => p.Length == int.Parse(value);
            }
            return null;
        }
    }
}
