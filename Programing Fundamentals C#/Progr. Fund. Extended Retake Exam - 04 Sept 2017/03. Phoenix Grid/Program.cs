using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.Phoenix_Grid
{
    class Program
    {
        static void Main()
        {
            string pattern = @"^[^\s_]{3}(\.[^\s_]{3})*$";
            string words = Console.ReadLine();
            while (words != "ReadMe")
            {
                Match match = Regex.Match(words, pattern);
                if (match.Success)
                {
                    if (IsPalindrome(match.Groups[0].Value))
                    {
                        Console.WriteLine("YES");
                    }
                    else
                    {
                        Console.WriteLine("NO");
                    }
                }
                else
                {
                    Console.WriteLine("NO");
                }
                words = Console.ReadLine();
            }
        }

        private static bool IsPalindrome(string value)
        {
            for (int i = 0; i < value.Length / 2; i++)
            {
                if (!(value[i] == value[value.Length - 1 - i]))
                {
                    return false; 
                }
            }
            return true;
        }
    }
}