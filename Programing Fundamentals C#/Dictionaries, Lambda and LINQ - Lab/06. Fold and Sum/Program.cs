using System;
using System.Linq;
using System.Collections.Generic;

namespace _06.Fold_and_Sum
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int k = numbers.Length / 4;
            var leftArr = numbers.Take(k).Reverse().ToArray();
            var rightArr = numbers.Skip(3 * k).Take(k).Reverse().ToArray();
            var middleArr = numbers.Skip(k).Take(2 * k).ToArray();
            
            var mergeLeftAndRight = leftArr.Concat(rightArr).ToArray();
            var sumArray = new int[2 * k];
            for (int i = 0; i < sumArray.Length; i++)
            {
                sumArray[i] = middleArr[i] + mergeLeftAndRight[i];
            }
            Console.WriteLine(String.Join(" ", sumArray));
        }
    }
}