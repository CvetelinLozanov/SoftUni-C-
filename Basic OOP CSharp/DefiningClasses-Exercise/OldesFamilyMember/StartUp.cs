using System;
using System.Collections.Generic;

namespace OldesFamilyMember
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Family family = new Family();
            List<Person> people = new List<Person>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Person person = new Person();
                string[] input = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                person.Name = input[0];
                person.Age = int.Parse(input[1]);

                family.AddPeople(person);
            }
            var oldestPerson = family.GetOldestPerson();
            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");

        }
    }
}
