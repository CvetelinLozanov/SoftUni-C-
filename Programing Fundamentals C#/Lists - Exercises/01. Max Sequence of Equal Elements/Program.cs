using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var bestStart = 0;
            var bestSequence = 1;
            var bestLength = 1;
            for (int i = 0; i < numbers.Count - 1; i++)
            {

                if (numbers[i] == numbers[i + 1])
                {
                    bestLength++;
                    if (bestLength > bestSequence)
                    {
                        bestSequence = bestLength;
                        bestStart = numbers[i];
                    }
                }
                else
                {
                    bestLength = 1;
                }
                if (bestSequence == 1)
                {
                    bestStart = numbers[0];
                }
            }
            for (int i = 0; i < bestSequence; i++)
            {
                Console.Write(bestStart + " ");
            }

        }
    }
}