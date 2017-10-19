using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;

namespace _08.Mentor_Group
{
    class Program
    {
        static void Main()
        {
            List<Student> students = ReadStudents();
            string nameAndComments = Console.ReadLine();
            List<string> empty = new List<string>();
            while (nameAndComments != "end of comments")
            {
                string[] tokens = nameAndComments.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                string comment = tokens[1];
                if (students.Any(s => s.Name == name))
                {
                    Student currentStudent = students.First(s => s.Name == name);
                    var oldComments = currentStudent.Comments;                    
                    currentStudent.Comments = oldComments;
                    if (currentStudent.Comments == null)
                    {
                        currentStudent.Comments = new List<string>();
                        currentStudent.Comments.Add(comment);                       
                    }
                    else
                    {
                        currentStudent.Comments.Add(comment);
                    }                    
                }
                nameAndComments = Console.ReadLine();
            }
            foreach (var student in students.OrderBy(s => s.Name))
            {
                Console.WriteLine(student.Name);
                Console.WriteLine("Comments: ");
                if (student.Comments != null)
                {
                    foreach (var comment in student.Comments)
                    {

                        Console.WriteLine($"- {comment}");

                    }
                }
                Console.WriteLine($"Dates attended:");
                foreach (var date in student.DateList.OrderBy(d => d))
                {
                    Console.WriteLine("-- " + date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
                }
            }
        }

        private static List<Student> ReadStudents()
        {
            string input = Console.ReadLine();
            List<Student> students = new List<Student>();
            while (input != "end of dates")
            {
                string[] tokens = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                List<DateTime> dates = new List<DateTime>();
                for (int i = 1; i < tokens.Length; i++)
                {
                    dates.Add(DateTime.ParseExact(tokens[i], "dd/MM/yyyy", CultureInfo.InvariantCulture));
                }
                if (students.Any(s => s.Name == name))
                {
                    Student oldStudent = students.First(s => s.Name == name);
                    oldStudent.DateList.AddRange(dates);
                }
                else
                {
                    Student student = new Student
                    {
                        Name = name,
                        DateList = dates,
                    };
                    students.Add(student);
                }
                input = Console.ReadLine();
            }
            return students;
        }
    }
    class Student
    {
        public string Name { get; set; }
        public List<string> Comments { get; set; }
        public List<DateTime> DateList { get; set; }
    }
}