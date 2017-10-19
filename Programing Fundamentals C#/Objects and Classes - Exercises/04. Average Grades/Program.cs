using System;
using System.Linq;
using System.Collections.Generic;

namespace _04.Average_Grades
{
    class Program
    {
        static void Main()
        {
            int lines = int.Parse(Console.ReadLine());
            List<Student> students = ReadStudents(lines);
            List<Student> excellentStudents = students.Where(g => g.Grade.Average() >= 5).OrderBy(s => s.Name).ThenByDescending(s => s.Grade.Average()).ToList();
           
            foreach (var student in excellentStudents)
            {
                Console.WriteLine($"{student.Name} -> {student.AverageGrade(student.Grade):F2}");
            }
        }

        private static List<Student> ReadStudents(int lines)
        {
            List<Student> students = new List<Student>();
            for (int i = 0; i < lines; i++)
            {
                var stuGrades = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                string name = stuGrades[0];
                var grades = new List<double>();
                for (int j = 1; j < stuGrades.Count; j++)
                {
                    grades.Add(double.Parse(stuGrades[j]));
                }
                Student student = new Student
                {
                    Name = name,
                    Grade = grades                    
                };
                students.Add(student);
            }
            return students;
        }
    }
    public class Student
    {
        public string Name { get; set; }
        public List<double> Grade { get; set; }
        public double AverageGrade(List<double> Grade)
        {
            return Grade.Average();
        }
    }
}