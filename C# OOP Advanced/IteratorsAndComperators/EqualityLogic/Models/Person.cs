using EqualityLogic.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EqualityLogic.Models
{
    public class Person : IPerson, IComparable<Person>
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public Person(string name, int age)
        {
            this.Name = name;

            this.Age = age;
        }

        public int CompareTo(Person other)
        {
            int result = this.Name.CompareTo(other.Name);

            if (result == 0)
            {
                result = this.Age.CompareTo(other.Age);
            }

            //if (result == 0)
            //{
            //    result = this.Town.CompareTo(other.Town);
            //}
            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj is Person other)
            {
                return this.Name == other.Name && this.Age == other.Age;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + this.Age.GetHashCode();
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Age}";
        }
    }
}
