using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _02.Line_Numbers
{
    class Program
    {
        static void Main()
        {
            string[] lines = File.ReadAllLines("input.txt");
            string[] numberedLines = new string[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                numberedLines[i] = ((i + 1) + ".  " + lines[i]);
            }
            File.WriteAllLines("output.txt", numberedLines);
        }
    }
}