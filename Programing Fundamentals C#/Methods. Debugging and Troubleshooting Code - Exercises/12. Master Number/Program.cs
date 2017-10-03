using System;

namespace _12.Master_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (int num = 1; num <= n; num++)
            {
                IsPalindrome(num);
                SumOfDigits(num);
                ContainsEvenDigit(num);

                if (IsPalindrome(num) == true && SumOfDigits(num) == true && ContainsEvenDigit(num) == true)
                    Console.WriteLine(num);
            }
        }

        static bool IsPalindrome(int num)
        {
            var numString = num.ToString();
            var minLength = 0;
            var maxLength = numString.Length - 1;

            while (true)
            {
                if (minLength > maxLength)
                    return true;

                char ch1 = numString[minLength];
                char ch2 = numString[maxLength];

                if (ch1 != ch2)
                    return false;

                minLength++;
                maxLength--;
            }
        }

        static bool SumOfDigits(int num)
        {
            var digitSum = 0;

            while (num != 0)
            {
                digitSum += num % 10;
                num /= 10;
            }

            if (digitSum % 7 == 0)
                return true;
            else
                return false;
        }

        static bool ContainsEvenDigit(int num)
        {
            var evenDigit = 0;

            while (num != 0)
            {
                evenDigit = num % 10;
                num /= 10;

                if (evenDigit % 2 == 0)
                    return true;
            }
            return false;
        }
    }
}