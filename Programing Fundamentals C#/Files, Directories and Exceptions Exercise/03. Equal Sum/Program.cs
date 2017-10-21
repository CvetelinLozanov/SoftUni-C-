using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace _03.Equal_Sum
{
    class Program
    {
        static void Main()
        {
           int[] nums = File.ReadAllText("input.txt").Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            for (int i = 0; i < nums.Length; i++)
            {
                int[] leftSide = nums.Take(i).ToArray();
                int[] rightSide = nums.Skip(i + 1).ToArray();
                if (leftSide.Sum() == rightSide.Sum())
                {
                    File.WriteAllText("output.txt", i.ToString());
                    break;
                }
            }
        }
    }
}