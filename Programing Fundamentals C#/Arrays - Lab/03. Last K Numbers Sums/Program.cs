using System;

namespace _03.Last_K_Numbers_Sums
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            long[] sequence = new long[n];
            sequence[0] = 1;
            for (int i = 1; i < n; i++)
            {
                long sum = 0L;
                for (int prev = i - k; prev <= i - 1; prev++)
                    if (prev >= 0)
                        sum += sequence[prev];
                sequence[i] = sum;
            }
            Console.WriteLine(String.Join(" ", sequence));
        }
       
    }
}