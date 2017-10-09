using System;
using System.Linq;

namespace _01.Remove_Negatives_and_Reverse
{
    class Program
    {
        static void Main()
        {
            var listOfNums = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(f => f >= 0)
                .Reverse()
                .ToList();
            if (listOfNums.Count < 1)
            {
                Console.WriteLine("Empty");
            }
            else
            {
                Console.WriteLine(String.Join(" ", listOfNums));
            }
            
        }
    }
}