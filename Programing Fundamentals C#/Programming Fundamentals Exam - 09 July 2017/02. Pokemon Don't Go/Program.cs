using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.Pokemon_Don_t_Go
{
    class Program
    {
        static void Main()
        {
            List<long> nums = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList();
            var sum = 0L;
            
            while (nums.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());
                long specialNum = 0L;
                if (index < 0)
                {
                    
                    specialNum = nums[0];                    
                    nums[0] = nums.Last();
                                      
                }
                else if (index > nums.Count - 1)
                {
                   
                    specialNum = nums[nums.Count - 1];
                    nums[nums.Count - 1] = nums.First();                   
                   
                }
                else
                {
                    specialNum = nums[index];                    
                    nums.RemoveAt(index);
                   
                }
                sum += specialNum;
                for (int i = 0; i < nums.Count; i++)
                {
                    if (nums[i] <= specialNum)
                    {
                        nums[i] += specialNum;
                    }
                    else
                    {
                        nums[i] -= specialNum;
                    }
                }

            }
            Console.WriteLine(sum);
        }
    }
}
