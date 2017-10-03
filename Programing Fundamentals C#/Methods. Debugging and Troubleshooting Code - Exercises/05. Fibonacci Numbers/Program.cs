using System;

namespace _05.Fibonacci_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int f0 = 1;
            int f1 = 1;
            for (int i = 0; i < n - 1; i++)
            {
                int sum = f0 + f1;
                f0 = f1;
                f1 = sum;
            }
            Console.WriteLine(f1);
        }
    }
}