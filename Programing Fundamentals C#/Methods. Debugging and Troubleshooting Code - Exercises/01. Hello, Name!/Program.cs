using System;

namespace _01.Hello__Name_
{

    class Program
    {
        static void Main(string[] args)
        {
            var name = Console.ReadLine();
            PrintName(name);
        }

        static void PrintName(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }
    }

}