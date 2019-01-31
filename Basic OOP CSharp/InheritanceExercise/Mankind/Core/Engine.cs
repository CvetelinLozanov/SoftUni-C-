using Mankind.Humans;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mankind.Core
{
    public class Engine
    {

        public void Run()
        {
            StringBuilder result = new StringBuilder();

            string[] studentInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            try
            {
                string studentFirstName = studentInput[0];
                string studentLastName = studentInput[1];
                string facultyNumber = studentInput[2];
                Student student = new Student(studentFirstName, studentLastName, facultyNumber);
                result.AppendLine(student.ToString());
                result.AppendLine();
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }

            string[] workerInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            try
            {
                string workerFirstName = workerInput[0];
                string workerLastName = workerInput[1];
                decimal workerSalary = decimal.Parse(workerInput[2]);
                int workHours = int.Parse(workerInput[3]);
                Worker worker = new Worker(workerFirstName,
                    workerLastName,
                    workerSalary,
                    workHours);
                result.AppendLine(worker.ToString());               
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0); 
            }

            Console.WriteLine(result.ToString());
        }
    }
}
