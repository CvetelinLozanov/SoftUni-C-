using System;
using System.Linq;

namespace SortEvenNumbers
{
    class SortEvenNumbers
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
            .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .Where(n => n % 2 == 0)
            .OrderBy(n => n)
            .ToArray();

            for (int i = 0; i < nums.Length - 1; i++)
            {
                Console.Write(nums[i] + ", ");
            }
            Console.WriteLine(nums[nums.Length - 1]);
        }
    }
}