using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace _04.Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main()
        {
            string[] input = File.ReadAllText("input.txt").Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}