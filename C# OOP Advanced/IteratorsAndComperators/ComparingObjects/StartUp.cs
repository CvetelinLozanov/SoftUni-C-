using ComparingObjects.Models;
using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class StartUp
    {
        public static void Main()
        {
            List<Person> people = new List<Person>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] args = input.Split();
                string name = args[0];
                int age = int.Parse(args[1]);
                string town = args[2];

                Person person = new Person(name, age, town);

                people.Add(person);

                input = Console.ReadLine();
            }

            int index = int.Parse(Console.ReadLine()) - 1;

            Person comparePerson = people[index];

            int equalPeople = 0;

            foreach (var person in people)
            {
                if (person.CompareTo(comparePerson) == 0)
                {
                    equalPeople++;
                }
            }

            if (equalPeople > 1)
            {
                int numberOfNotEqualPeople = people.Count - equalPeople;
                Console.WriteLine($"{equalPeople} {numberOfNotEqualPeople} {people.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
