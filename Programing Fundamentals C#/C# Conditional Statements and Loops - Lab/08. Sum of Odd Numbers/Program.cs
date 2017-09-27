using System;

namespace _08.Sum_of_Odd_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var cnt = 1;
            var sum = 0;
            for (int i = n; i >= 1; i--)
            {
                sum += cnt;
                Console.WriteLine(cnt);
                cnt += 2;
            }
            Console.WriteLine("Sum: {0}", sum);
        }
    }
}