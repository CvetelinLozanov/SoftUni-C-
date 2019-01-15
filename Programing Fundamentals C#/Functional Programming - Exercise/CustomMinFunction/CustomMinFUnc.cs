using System;
using System.Linq;

namespace CustomMinFunction
{
    class CustomMinFunc
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine()
                 .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();
            int minNum = findMinNumber(inputNumbers);
            Console.WriteLine(minNum);
            
        }
        public static Func<int[], int> findMinNumber = nums =>
             {
                 int minNum = int.MaxValue;
                 for (int i = 0; i < nums.Length; i++)
                 {
                     if (minNum > nums[i])
                     {
                         minNum = nums[i];
                     }
                 }
                 return minNum;
             };
    }
}
