using System;

namespace _06.Prime_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = long.Parse(Console.ReadLine());
            var isPrime = IsPrime(num);
            Console.WriteLine(isPrime);
        }
        static bool IsPrime(long num)
        {
            if (num == 0 || num == 1)
            {
                return false;
            }
            if (num == 2)
            {
                return true;
            }
            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}