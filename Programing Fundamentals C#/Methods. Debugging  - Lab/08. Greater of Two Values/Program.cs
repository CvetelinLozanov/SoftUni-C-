using System;

namespace _08.Greater_of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            switch (input)
            {
                case "int":
                    int number1 = int.Parse(Console.ReadLine());
                    int number2 = int.Parse(Console.ReadLine());
                    int biggerNumber = GetMaxInteger(number1, number2);
                    Console.WriteLine(biggerNumber);
                    break;
                case "char":
                    char character1 = char.Parse(Console.ReadLine());
                    char character2 = char.Parse(Console.ReadLine());
                    char biggerCharacter = GetBiggerCharacter(character1, character2);
                    Console.WriteLine(biggerCharacter);
                    break;
                case "string":
                    string string1 = Console.ReadLine();
                    string string2 = Console.ReadLine();
                    string biggerString = GetBiggerString(string1, string2);
                    Console.WriteLine(biggerString);
                    break;
            }
        }

        private static string GetBiggerString(string string1, string string2)
        {
            if (string1.CompareTo(string2) >= 0)
            {
                return string1;
            }
            else
            {
                return string2;
            }
        }

        private static char GetBiggerCharacter(char character1, char character2)
        {
            if (character1 > character2)
            {
                return character1;
            }
            else
            {
                return character2;
            }
        }

        private static int GetMaxInteger(int number1, int number2)
        {
            return Math.Max(number1, number2);
        }
    }
}