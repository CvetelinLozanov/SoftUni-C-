using System;
using System.Linq;

namespace AddVAT
{
    class AddVat
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(n => n * 1.2)
                .ToList()
                .ForEach(n => Console.WriteLine($"{n:F2}"));
        }
    }
}