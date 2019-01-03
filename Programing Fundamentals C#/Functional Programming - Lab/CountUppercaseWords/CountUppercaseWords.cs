using System;
using System.Linq;

namespace CountUppercaseWords
{
    class CountUppercaseWords
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                 .Where(w => Char.IsUpper(w[0]))
                 .ToList()
                 .ForEach(Console.WriteLine);

        }
    }
}