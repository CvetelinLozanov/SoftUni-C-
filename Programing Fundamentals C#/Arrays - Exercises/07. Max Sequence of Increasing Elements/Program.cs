using System;
using System.Linq;
namespace _07.Max_Sequence_of_Increasing_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int index = 0;
            int length = 1;
            int bestIndex = 0;
            int bestLenght = 0;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[i - 1])
                {
                    length++;
                    if (length > bestLenght)
                    {
                        bestLenght = length;
                        bestIndex = index;
                    }
                }
                else
                {
                    length = 1;
                    index = i;
                }
            }
            for (int i = 0; i < bestLenght; i++)
            {
                Console.Write(nums[bestIndex++] + " ");
            }
        }
    }
}