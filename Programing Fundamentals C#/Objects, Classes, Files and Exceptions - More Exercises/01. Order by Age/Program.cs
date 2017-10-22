using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.Order_by_Age
{
    class Program
    {
        static void Main()
        {
            List<Person> people = ReadPeople();
            List<Person> orderedPeople = people.OrderBy(p => p.Age).ToList();
            foreach (var person in orderedPeople)
            {
                Console.WriteLine($"{person.Name} with ID: {person.Id} is {person.Age} years old.");
            }
        }

        private static List<Person> ReadPeople()
        {
            List<Person> people = new List<Person>();
            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] tokens = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Person person = new Person()
                {
                    Name = tokens[0],
                    Id = tokens[1],
                    Age = int.Parse(tokens[2]),
                };
                people.Add(person);
                command = Console.ReadLine();
            }
            return people;
        }
    }
    public class Person
    {
        public string Name { get; set; }

        public string Id { get; set; }

        public int Age { get; set; }
    }
}