using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace _08.Average_Grades
{
    class Program
    {
        static void Main()
        {
            string[] input = File.ReadAllLines("input.txt");
            int n = int.Parse(input[0]);
            List<Student> students = ReadStudents(n, input);
            List<Student> studentss = students
                .Where(s => s.AverageGrade >= 5)
                .OrderBy(s => s.Name)
                .ToList();
            File.Delete("output.txt");
            foreach (var student in studentss)
            {
                File.AppendAllText("output.txt", ($"{student.Name} -> {student.Grades.Average():F2}{Environment.NewLine}"));
            }
        }

        private static List<Student> ReadStudents(int n, string[] input)
        {
            var students = new List<Student>();
            string[] studentss = input.Skip(1).ToArray();
            
            for (int i = 0; i < n; i++)
            {
                string[] studentArgs = studentss[i]
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name = studentArgs[0];
                List<double> grades = new List<double>();
                for (int j = 1; j < studentArgs.Length; j++)
               {
                    grades.Add(double.Parse(studentArgs[j]));
               }
                Student student = new Student
                {
                    Name = name,
                    Grades = grades,                    
                };
                students.Add(student); 
            }
            return students;
        }
    }
    public class Student
    {
        public string Name { get; set; }

        public List<double> Grades { get; set; }

        public double AverageGrade => Grades.Average();
        
    }
}