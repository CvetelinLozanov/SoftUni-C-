using System;
using System.IO;
using System.Linq;


namespace _01.Odd_Lines
{
    class Program
    {
        static void Main()
        {
            string[] lines = File.ReadAllLines("input.txt");
            string[] oddLines = lines.Where((line, i) => i % 2 == 1).ToArray();
            File.WriteAllLines("output.txt", oddLines);
        }
    }
}