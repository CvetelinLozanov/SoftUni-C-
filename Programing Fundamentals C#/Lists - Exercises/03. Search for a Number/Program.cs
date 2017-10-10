using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.Search_for_a_Number
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            var filterNums = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int numbersToTake = filterNums[0];
            int numsToDelete = filterNums[1];
            int specialNum = filterNums[2];
            numbers.Take(numbersToTake);
            numbers.RemoveRange(0, numsToDelete);
            if (numbers.Contains(specialNum))
            {
                Console.WriteLine("YES!");
            }
            else
            {
                Console.WriteLine("NO!");
            }
        }
    }
}