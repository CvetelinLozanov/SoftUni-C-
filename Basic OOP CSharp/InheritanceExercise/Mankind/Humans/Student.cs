using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Mankind.Humans
{
    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber) 
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get { return facultyNumber; }
            set
            {
                if (IsNumberInvalid(value))
                {
                    throw new FormatException("Invalid faculty number!");  
                }
                facultyNumber = value;
            }
        }

        private bool IsNumberInvalid(string value)
        {
            bool isNumberInvalid = false;

            string numberPattern = @"^([0-9a-zA-Z]{5,10})$";

            var regex = new Regex(numberPattern);

            var match = regex.Match(value);

            if (match.Success)
            {
                return isNumberInvalid;
            }

            return !isNumberInvalid;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(base.ToString());

            result.AppendLine($"Faculty Number: {this.FacultyNumber}");

            return result.ToString().Trim();
        }
    }
}
