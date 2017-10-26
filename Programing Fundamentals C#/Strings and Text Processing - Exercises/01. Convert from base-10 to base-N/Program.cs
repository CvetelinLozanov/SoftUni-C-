using System;
using System.Collections.Generic;
using System.Numerics;

namespace _01.Convert_from_base_10_to_base_N
{
    class Program
    {
        static void Main()
        {

            string[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            byte baseN = byte.Parse(numbers[0]);
            BigInteger number = BigInteger.Parse(numbers[1]);
            List<BigInteger> nums = new List<BigInteger>();
            BigInteger curNum = 0;
            while (number > 0)
            {
                curNum = number % baseN;
                nums.Add(curNum);
                number /= baseN;
            }
            nums.Reverse();
            Console.WriteLine(string.Join("", nums));
        }
    }
}