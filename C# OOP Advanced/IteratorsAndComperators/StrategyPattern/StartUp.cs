using StrategyPattern.Comperators;
using StrategyPattern.Models;
using System;
using System.Collections.Generic;

namespace StrategyPattern
{
    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<Person> peopleByName = new SortedSet<Person>(new PersonByName());
            SortedSet<Person> peopleByAge = new SortedSet<Person>(new PersonByAge());

            while (n-- > 0)
            {
                string[] args = Console.ReadLine().Split();
                string name = args[0];
                int age = int.Parse(args[1]);

                Person person = new Person(name, age);

                peopleByName.Add(person);
                peopleByAge.Add(person);
            }

            Console.WriteLine(string.Join("\n", peopleByName));
            Console.WriteLine(string.Join("\n", peopleByAge));
        }
    }
}
