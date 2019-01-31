using System;
using System.Collections.Generic;
using System.Text;

namespace Mankind.Humans
{
    public class Worker : Human
    {
        private decimal salary;
        private int workHours;

        public Worker(string firstName, string lastName, decimal salary, int workHours) 
            : base(firstName, lastName)
        {
            this.Salary = salary;
            this.WorkHours = workHours;
        }

        public decimal Salary
        {
            get { return salary; }
            set
            {
                if (value < 10)
                {
                    throw new FormatException($"Expected value mismatch! Argument: {value}");
                }
                salary = value;
            }
        }

        public int WorkHours
        {
            get { return workHours; }
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new FormatException($"Expected value mismatch! Argument: {value}");
                }
                workHours = value;
            }
        }

        public decimal SalaryPerHour { get => GetSalaryPerHour(); }

        private decimal GetSalaryPerHour()
        {
            return (Salary / 5) / WorkHours;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.ToString());

            sb.AppendLine($"Week Salary: {this.Salary:F2}");
            sb.AppendLine($"Hours per day: {this.WorkHours:F2}");
            sb.AppendLine($"Salary per hour: {this.SalaryPerHour:F2}");

            return sb.ToString().Trim();
        }
    }
}
