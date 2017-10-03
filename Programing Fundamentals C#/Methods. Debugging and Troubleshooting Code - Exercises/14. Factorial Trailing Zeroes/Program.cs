using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace _14.Factorial_Trailing_Zeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());
            BigInteger factoriel = 1;
            factoriel = NewMethod(num, factoriel);
            var zerosInFactoriel = GetTrailingZeroes(factoriel);
            Console.WriteLine(zerosInFactoriel);

        }

        static BigInteger GetTrailingZeroes(BigInteger factoriel)
        {

            BigInteger timesZero = 0;
            while (factoriel % 10 == 0)
            {
                factoriel = factoriel / 10;
                timesZero++;
            }
            return timesZero;
        }

        static BigInteger NewMethod(int num, BigInteger factoriel)
        {
            for (int i = 1; i <= num; i++)
            {
                factoriel *= i;
            }
            return factoriel;
        }
    }
}