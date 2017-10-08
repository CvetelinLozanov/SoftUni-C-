using System;
using System.Linq;

namespace _06.Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int startPos = 0;
            int length = 1;
            int bestSequence = 0;
            int bestLength = 0;
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] == numbers[i - 1])
                {
                    length++;
                    if (length > bestLength)
                    {
                        bestLength = length;
                        bestSequence = startPos;
                    }

                }
                else
                {
                    length = 1;
                    startPos = i;
                }
            }
            for (int i = 0; i < bestLength; i++)
            {
                Console.Write(numbers[bestSequence++] + " ");
            }
        }
    }
}