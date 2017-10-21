using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace _02.Index_of_Letters
{
    class Program
    {
        static void Main()
        {
            char[] chars = File.ReadAllText("input.txt").ToCharArray();
            File.WriteAllText("output.txt", "");
            for (int i = 0; i < chars.Length; i++)
            {
                File.AppendAllText("output.txt", chars[i] + " -> " + (int)(chars[i] - 97) + Environment.NewLine);
            }
        }
    }
}