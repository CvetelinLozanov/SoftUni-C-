namespace EqualityLogic
{
    using EqualityLogic.Models;
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<Person> sortedPeople = new SortedSet<Person>();
            HashSet<Person> peopleByHash = new HashSet<Person>();

            while (n-- > 0)
            {
                string[] args = Console.ReadLine().Split();
                string name = args[0];
                int age = int.Parse(args[1]);

                Person person = new Person(name, age);

                sortedPeople.Add(person);
                peopleByHash.Add(person);
            }

            Console.WriteLine(sortedPeople.Count);
            Console.WriteLine(peopleByHash.Count);
        }
    }
}
