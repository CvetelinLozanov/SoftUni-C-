using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _07.Primes_in_Given_Range
{

    class Program
    {
        static void Main(string[] args)
        {
            var startNum = int.Parse(Console.ReadLine());
            var endNum = int.Parse(Console.ReadLine());
            var primesInRange = FindPrimesInRange(startNum, endNum);
            Console.WriteLine(string.Join(", ", primesInRange));
        }

        static List<int> FindPrimesInRange(int startNum, int endNum)
        {
            var primes = new List<int>();
            for (int currentnum = startNum; currentnum <= endNum; currentnum++)
            {
                if (IsPrime(currentnum))
                {
                    primes.Add(currentnum);
                }
            }
            return primes;

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