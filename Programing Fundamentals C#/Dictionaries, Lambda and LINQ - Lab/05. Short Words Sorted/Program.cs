using System;
using System.Linq;
using System.Collections.Generic;

namespace _05.Short_Words_Sorted
{
    class Program
    {
        static void Main()
        {
            //. , : ; ( ) [ ] " ' \ / ! ? 
            var result = Console.ReadLine()
                .ToLower()
                .Split(new char[] { ' ', '.', ',', ':', ';', '(', ')', '[', ']', '"', '\'', '/', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(w => w.Length < 5)
                .OrderBy(w => w)
                .Distinct()
                .ToArray();
            Console.WriteLine(String.Join(", ", result));

        }
    }
}