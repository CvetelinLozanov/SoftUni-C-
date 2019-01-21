using System;
using System.Collections.Generic;
using System.Linq;

namespace Google
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var people = new Dictionary<string, Person>();
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] inputArgs = input
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string name = inputArgs[0];
                if (!people.ContainsKey(name))
                {                    
                    people.Add(name, new Person(name));
                }

                SetParameters(people, inputArgs, name);
                input = Console.ReadLine();
            }

            string searchedName = Console.ReadLine();
            Person person = people.Values.FirstOrDefault(x => x.Name == searchedName);
            Console.WriteLine(person);
        }

        private static void SetParameters(Dictionary<string, Person> people, string[] inputArgs, string name)
        {
            switch (inputArgs[1])
            {
                case "car":
                    string carModel = inputArgs[2];
                    int carSpeed = int.Parse(inputArgs[3]);
                    Car car = new Car(carModel, carSpeed);
                    people[name].Car = car;
                    break;
                case "parents":
                    string parentName = inputArgs[2];
                    string parentBirthday = inputArgs[3];
                    Parent parent = new Parent(parentName, parentBirthday);
                    people[name].Parents.Add(parent);
                    break;
                case "pokemon":
                    string pokemonName = inputArgs[2];
                    string pokemonType = inputArgs[3];
                    Pokemon pokemon = new Pokemon(pokemonName, pokemonType);
                    people[name].Pokemons.Add(pokemon);
                    break;
                case "company":
                    string companyName = inputArgs[2];
                    string department = inputArgs[3];
                    decimal salary = decimal.Parse(inputArgs[4]);
                    Company company = new Company(companyName, department, salary);
                    people[name].Company = company;
                    break;
                case "children":
                    string childName = inputArgs[2];
                    string childBirthday = inputArgs[3];
                    Child child = new Child(childName, childBirthday);
                    people[name].Children.Add(child);
                    break;
            }
        }
    }
}
