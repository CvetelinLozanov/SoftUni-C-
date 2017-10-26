using System;
using System.Collections.Generic;

namespace _06.Sum_big_numbers
{
    class Program
    {
        static void Main()
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();
            if (first.Length > second.Length)
            {
                second = second.PadLeft(first.Length, '0');
            }
            else
            {
                first = first.PadLeft(second.Length, '0');
            }
            List<int> result = new List<int>();
            int sum = 0;
            int reminder = 0;
            int number = 0;
            for (int i = first.Length - 1; i >= 0; i--)
            {
                sum = first[i] - 48 + second[i] - 48 + reminder;
                number = sum % 10;
                result.Add(number);
                reminder = sum / 10;
                if (i == 0 && reminder > 0)
                {
                    result.Add(reminder);
                }
            }
            result.Reverse();
            string res = String.Join("", result);
            Console.WriteLine(res.TrimStart('0'));
        }
    }
}