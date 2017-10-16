using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.Sort_Times
{
    class Program
    {
        static void Main()
        {
            var time = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).OrderBy(a => a).ToList();
            Console.WriteLine(String.Join(", ", time));
        }
    }
}