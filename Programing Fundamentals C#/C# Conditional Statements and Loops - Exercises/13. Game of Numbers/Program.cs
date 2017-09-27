using System;

namespace _13.Game_of_Numbers
{

    class Program
    {
        static void Main()
        {
            var N = int.Parse(Console.ReadLine());
            var M = int.Parse(Console.ReadLine());
            var ControlNum = int.Parse(Console.ReadLine());
            var lastCombination = string.Empty;
            var cnt = 0;
            var sum = 0.0;
            for (int i = N; i <= M; i++)
            {
                for (int j = N; j <= M; j++)
                {
                    cnt++;
                    sum = i + j;
                    if (sum == ControlNum && i > j)
                    {
                        lastCombination = $"Number found! {i} + {j} = {ControlNum}";
                    }
                }
            }
            if (lastCombination == string.Empty)
            {
                Console.WriteLine($"{cnt} combinations - neither equals {ControlNum}");
            }
            else
            {
                Console.WriteLine(lastCombination);
            }
        }
    }
}