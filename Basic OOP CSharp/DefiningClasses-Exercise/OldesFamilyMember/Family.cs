using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OldesFamilyMember
{
    public class Family
    {
        private List<Person> persons;

        public Family()
        {
            this.Persons = new List<Person>();
        }

        public List<Person> Persons
        {
            get { return persons; }
            set { persons = value; }
        }

        public void AddPeople(Person person)
        {
            Persons.Add(person);
        }

        public Person GetOldestPerson()
        {
            return Persons.OrderByDescending(x => x.Age).FirstOrDefault();
        }

    }
}
