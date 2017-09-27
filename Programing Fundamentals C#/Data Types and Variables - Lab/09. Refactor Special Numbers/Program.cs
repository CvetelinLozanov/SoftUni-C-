using System;

namespace _09.Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            for (int num = 1; num <= n; num++)
            {
                int sum = SumOfDigits(num);
                bool special = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine($"{num} -> {special}");
            }
        }

        static int SumOfDigits(int num)
        {
            int sum = 0;
            while (num > 0)
            {
                sum += num % 10;
                num /= 10;
            }

            return sum;
        }
    }
}