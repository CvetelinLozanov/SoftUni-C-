using System;

namespace _09.Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            if (number < 0)
            {
                number = Math.Abs(number);
            }
            int evenSum = GetEvenSum(number);
            int oddSum = GetOddSum(number);
            long multiplyTwoNums = (long)evenSum * oddSum;
            Console.WriteLine(multiplyTwoNums);
        }

        private static int GetOddSum(int number)
        {
            int oddSum = 0;
            int num = 0;
            while (number > 0)
            {
                num = number % 10;
                if (num % 2 == 1)
                {
                    oddSum += num;
                }
                number /= 10;
            }
            return oddSum;
        }

        private static int GetEvenSum(int number)
        {
            int evenSum = 0;
            int num = 0;
            while (number > 0)
            {
                num = number % 10;
                if (num % 2 == 0)
                {
                    evenSum += num;
                }
                number /= 10;
            }
            return evenSum;

        }
    }
}