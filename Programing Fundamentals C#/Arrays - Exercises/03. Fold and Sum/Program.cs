using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int k = numbers.Length / 4;
            int[] middleArray = new int[2 * k];
            int[] leftAndRightSide = new int[2 * k];
            int[] sumArray = new int[2 * k];

            for (int i = 0; i < k; i++)
            {
                leftAndRightSide[i] = numbers[k - 1 - i];
                leftAndRightSide[2 * k - 1 - i] = numbers[numbers.Length - k + i];
            }
            for (int i = 0; i < 2 * k; i++)
            {
                middleArray[i] = numbers[k + i];
            }
            for (int i = 0; i < sumArray.Length; i++)
            {
                sumArray[i] = leftAndRightSide[i] + middleArray[i];
            }
            Console.WriteLine(String.Join(" ", sumArray));
        }
    }
}