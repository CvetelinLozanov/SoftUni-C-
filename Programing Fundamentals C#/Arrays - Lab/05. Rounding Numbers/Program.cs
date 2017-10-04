using System;
using System.Linq;

namespace _05.Rounding_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] nums = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            double[] numsCopy = new double[nums.Length];
            double[] roundedNums = new double[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                numsCopy[i] = nums[i];
                
                if (nums[i] > 0)
                {
                    nums[i] += 0.5;
                    roundedNums[i] = Math.Truncate(nums[i]);
                }
                else
                {
                    nums[i] -= 0.5;
                    roundedNums[i] = Math.Truncate(nums[i]);
                }
                
                Console.WriteLine($"{numsCopy[i]} => {roundedNums[i]}");
            }
            
        }
    }
}