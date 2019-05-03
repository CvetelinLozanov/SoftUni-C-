namespace StrategyPattern.Comperators
{
    using StrategyPattern.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PersonByName : IComparer<Person>
    {
        public int Compare(Person firstPerson, Person secondPerson)
        {
            int result = firstPerson.Name.Length.CompareTo(secondPerson.Name.Length);
            if (result == 0)
            {
                char firstPersonLetter = char.ToLower(firstPerson.Name[0]);
                char secondPersonLetter = char.ToLower(secondPerson.Name[0]);
                result = firstPersonLetter.CompareTo(secondPersonLetter);
            }
            return result;
        }
    }
}
