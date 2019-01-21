using System;
using System.Collections.Generic;
using System.Linq;

namespace OpinionPoll
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Person> members = new List<Person>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Person person = new Person();
                string[] input = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                int age = int.Parse(input[1]);

                person.Name = name;
                person.Age = age;

                members.Add(person);
            }
            var olderPeople = members.Where(x => x.Age > 30).OrderBy(x => x.Name).ToList();

            foreach (var person in olderPeople)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }

        }
    }
}
