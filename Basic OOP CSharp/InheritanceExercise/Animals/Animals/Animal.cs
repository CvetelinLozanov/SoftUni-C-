using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.Animals
{
    public abstract class Animal
    {
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    InvalidInputException();
                }
                name = value;
            }
        }

        public int Age
        {
            get { return age; }
            private set
            {
                if (value < 0)
                {
                    InvalidInputException();
                }
                age = value;
            }
        }

        public string Gender
        {
            get { return gender; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    InvalidInputException();
                }
                gender = value;
            }
        }

        private void InvalidInputException()
        {
            throw new Exception("Invalid input!");
        }

       public virtual void ProduceSound()
        {
            Console.WriteLine("scream");
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Age} {this.Gender}";
        }
    }
}
