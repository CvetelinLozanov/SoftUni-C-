using System;
using System.Numerics;
using System.Collections.Generic;

namespace _02.Convert_from_base_N_to_base_10
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);            
            byte baseN = byte.Parse(input[0]);
            string number = input[1];
            int pow = 0;
            BigInteger convertedNum = 0;
            for (int i = number.Length - 1; i >= 0; i--)
            {
                BigInteger num = BigInteger.Parse(number[i].ToString());
                convertedNum += num * BigInteger.Pow(baseN, pow);
                pow++;
            }
            Console.WriteLine(convertedNum);
        }
    }
}