using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyRoster
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {

                string input = Console.ReadLine();
                string[] commandArgs = input
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string name = commandArgs[0];
                decimal salary = decimal.Parse(commandArgs[1]);
                string position = commandArgs[2];
                string department = commandArgs[3];
                Employee employee = new Employee(name, salary, position, department);

                if (commandArgs.Length == 5)
                {
                    if (commandArgs[4].Contains('@'))
                    {
                        employee.Email = commandArgs[4];
                    }
                    else
                    {
                        employee.Age = int.Parse(commandArgs[4]);
                    }

                }
                else
                {
                    employee.Email = commandArgs[4];
                    employee.Age = int.Parse(commandArgs[5]);
                }
                employees.Add(employee);
            }
            var departmentWithHighestSalary = employees.GroupBy(x => x.Department)
                .ToDictionary(x => x.Key, y => y.Select(s => s))
                .OrderByDescending(x => x.Value.Average(s => s.Salary))
                .FirstOrDefault();

            Console.WriteLine($"Highest Average Salary: {departmentWithHighestSalary.Key}");
            foreach (var employee in departmentWithHighestSalary.Value.OrderByDescending(x => x.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:F2} {employee.Email} {employee.Age}");
            }
        }
    }
}
