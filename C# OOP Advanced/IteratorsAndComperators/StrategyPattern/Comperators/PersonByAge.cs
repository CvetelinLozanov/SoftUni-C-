namespace StrategyPattern.Comperators
{
    using StrategyPattern.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PersonByAge : IComparer<Person>
    {
        public int Compare(Person firstPerson, Person secondPerson)
        {
            return firstPerson.Age.CompareTo(secondPerson.Age);
        }
    }
}
