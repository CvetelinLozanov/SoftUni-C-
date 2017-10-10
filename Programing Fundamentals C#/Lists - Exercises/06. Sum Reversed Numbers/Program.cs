using System;
using System.Linq;
using System.Collections.Generic;

namespace _06.Sum_Reversed_Numbers
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int sum = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                int rev = 0;
                while (numbers[i] > 0)
                {

                    int r = numbers[i] % 10;
                    rev = rev * 10 + r;
                    numbers[i] = numbers[i] / 10;
                }
                sum += rev;
            }
            Console.WriteLine(sum);

              
        }
    }
}