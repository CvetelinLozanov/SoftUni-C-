using System;
using System.Linq;

namespace _01.Largest_Common_End
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = Console.ReadLine().Split(' ').ToArray();
            string[] arr2 = Console.ReadLine().Split(' ').ToArray();
            int leftCnt = 0;
            int rightCnt = 0;
            int minLength = Math.Min(arr1.Length, arr2.Length);
            for (int i = 0; i < minLength; i++)
            {
                if (arr1[i] == arr2[i])
                {
                    leftCnt++;
                }
                if (arr1[arr1.Length - 1 - i] == arr2[arr2.Length - 1 - i])
                {
                    rightCnt++;
                }
            }
            int maxSequence = Math.Max(leftCnt, rightCnt);
          
            Console.WriteLine(maxSequence);
        }
    }
}