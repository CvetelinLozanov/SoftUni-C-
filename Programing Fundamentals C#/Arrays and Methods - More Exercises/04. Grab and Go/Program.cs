using System;
using System.Linq;

namespace _04.Grab_and_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                 .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();
            int n = int.Parse(Console.ReadLine());
            int index = 0;
            bool isFound = false;
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                if (numbers[i] == n)
                {
                    index = i;
                    isFound = true;
                    break;
                }
            }
            
            if (isFound)
            {
                long sum = 0;
                for (int i = 0; i < index; i++)
                {
                    sum += numbers[i];
                }
                Console.WriteLine(sum);
            }
            else
            {
                Console.WriteLine("No occurrences were found!");
            }
            
        }
    }
}