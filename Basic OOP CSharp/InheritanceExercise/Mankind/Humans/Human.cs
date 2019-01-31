using System;
using System.Collections.Generic;
using System.Text;

namespace Mankind.Humans
{
    public abstract class Human
    {
        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (!char.IsUpper(value[0]))
                {
                    throw new FormatException($"Expected upper case letter! Argument: firstName");
                }
                if (value.Length < 3)
                {
                    throw new FormatException($"Expected length at least 4 symbols! Argument: firstName");
                }
                firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (!char.IsUpper(value[0]))
                {
                    throw new FormatException($"Expected upper case letter! Argument: lastName");
                }
                if (value.Length < 2)
                {
                    throw new FormatException($"Expected length at least 3 symbols! Argument: lastName");
                }
                lastName = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"First Name: {this.FirstName}");
            sb.AppendLine($"Last Name: {this.LastName}");
            return sb.ToString();
        }
    }
}
