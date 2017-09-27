using System;

namespace _04.Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            var persons = int.Parse(Console.ReadLine());
            var capacity = int.Parse(Console.ReadLine());
            var courses = Math.Ceiling((double)persons / capacity);
            Console.WriteLine(courses);
        }
    }
}