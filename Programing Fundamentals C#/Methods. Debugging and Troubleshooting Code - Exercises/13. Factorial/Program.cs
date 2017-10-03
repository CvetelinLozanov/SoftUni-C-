using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace _13.Factorial
{

    class Program
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());
            BigInteger factoriel = 1;
            factoriel = NewMethod(num, factoriel);
            Console.WriteLine(factoriel);

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