using System.Collections.Generic;
using System.Text;

namespace Google
{
    public class Person
    {
        private string name;
        private Company company;
        private List<Child> children;
        private List<Pokemon> pokemons;
        private List<Parent> parents;
        private Car car;

        public Person(string name)
        {
            Name = name;
            Children = new List<Child>();
            Pokemons = new List<Pokemon>();
            Parents = new List<Parent>();
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Car Car
        {
            get { return car; }
            set { car = value; }
        }
        public Company Company
        {
            get { return company; }
            set { company = value; }
        }

        public List<Parent> Parents
        {
            get { return parents; }
            set { parents = value; }
        }

        public List<Child> Children
        {
            get { return children; }
            set { children = value; }
        }    

        public List<Pokemon> Pokemons
        {
            get { return pokemons; }
            set { pokemons = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name}")
            .AppendLine($"Company:");
            if (Company != null)
            {
                sb.AppendLine($"{this.Company.ToString()}");
            }

            sb.AppendLine("Car:");
            if (Car != null)
            {
                sb.AppendLine($"{this.Car.ToString()}");
            }

            sb.AppendLine("Pokemon");

            if (Pokemons.Count > 0)
            {
                foreach (var pokemon in this.Pokemons)
                {
                    sb.AppendLine(pokemon.ToString());
                }
            }

            sb.AppendLine("Parents:");

            if (Parents.Count > 0)
            {
                foreach (var parent in this.Parents)
                {
                    sb.AppendLine(parent.ToString());
                }
            }

            sb.AppendLine("Children:");

            if (Children.Count > 0)
            {
                foreach (var child in Children)
                {
                    sb.AppendLine(child.ToString()); 
                }
            }

            return sb.ToString().Trim();
        }
    }
}
