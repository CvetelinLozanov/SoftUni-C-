using System;

namespace _09.Reversed_chars
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstLetter = char.Parse(Console.ReadLine());
            var secondLetter = char.Parse(Console.ReadLine());
            var thirdLetter = char.Parse(Console.ReadLine());
            Console.WriteLine("{0}{1}{2}", thirdLetter, secondLetter, firstLetter);
        }
    }
}