using System;
using System.Linq;
using System.Collections.Generic;

namespace _05.Magic_exchangeable_words
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            char[] firstWord = input[0].Distinct().ToArray();
            char[] secondWord = input[1].Distinct().ToArray();
            if (firstWord.Length == secondWord.Length)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
}