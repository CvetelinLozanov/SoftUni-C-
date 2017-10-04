using System;
using System.Linq;

namespace _06.Reverse_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] letters = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] reversedLetters = new string[letters.Length];
            for (int i = 0; i < letters.Length; i++)
            {
                reversedLetters[i] = letters[letters.Length - 1 - i];
            }
            Console.WriteLine(String.Join(" ", reversedLetters));
        }
    }
}