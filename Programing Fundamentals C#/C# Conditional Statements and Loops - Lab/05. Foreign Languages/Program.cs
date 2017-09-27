using System;

namespace _05.Foreign_Languages
{
    class Program
    {
        static void Main(string[] args)
        {
            var Country = Console.ReadLine();
            switch (Country)
            {
                case "England":
                case "USA":
                    Console.WriteLine("English"); break;
                case "Spain":
                case "Argentina":
                case "Mexico":
                    Console.WriteLine("Spanish"); break;
                default:
                    Console.WriteLine("unknown"); break;
            }
        }
    }
}