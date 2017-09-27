using System;

namespace _12.Test_Numbers
{
    class Program
    {
        static void Main()
        {
            var N = int.Parse(Console.ReadLine());
            var M = int.Parse(Console.ReadLine());
            var ControlNum = int.Parse(Console.ReadLine());
            var sum = 0.0;
            var cnt = 0;
            for (int i = N; i >= 1; i--)
            {
                for (int j = 1; j <= M; j++)
                {
                    if (sum < ControlNum)
                    {
                        sum += (i * j) * 3;
                        cnt++;
                    }
                }
            }
            if (sum >= ControlNum)
            {
                Console.WriteLine($"{cnt} combinations");
                Console.WriteLine($"Sum: {sum} >= {ControlNum}");
            }
            else
            {
                Console.WriteLine($"{cnt} combinations");
                Console.WriteLine($"Sum: {sum}");
            }
        }
    }
}