using System;

namespace _15.Fast_Prime_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            for (int numbers = 2; numbers <= N; numbers++)
            {
                bool isTrue = PrimeCheck(numbers);
                Console.WriteLine($"{numbers} -> {isTrue}");
            }


        }

        static bool PrimeCheck(int numbers)
        {
            bool isTrue = true;
            for (int divide = 2; divide <= Math.Sqrt(numbers); divide++)
            {
                if (numbers % divide == 0)
                {
                    isTrue = false;
                    break;
                }
            }
            return isTrue;
        }
    }
}