using System;

namespace _08.Employee_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstName = Console.ReadLine();
            var lastname = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var gender = Console.ReadLine();
            var personalID = long.Parse(Console.ReadLine());
            var employNum = int.Parse(Console.ReadLine());
            Console.WriteLine($"First name: {firstName}");
            Console.WriteLine($"Last name: {lastname}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Gender: {gender}");
            Console.WriteLine($"Personal ID: {personalID}");
            Console.WriteLine($"Unique Employee number: {employNum}");
        }
    }
}