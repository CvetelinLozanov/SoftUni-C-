using System;

namespace _14.Magic_Letter
{
    class Program
    {
        static void Main()
        {
            var N = char.Parse(Console.ReadLine());
            var M = char.Parse(Console.ReadLine());
            var ControlNum = char.Parse(Console.ReadLine());
            for (char i = N; i <= M; i++)
            {
                for (char j = N; j <= M; j++)
                {
                    for (char k = N; k <= M; k++)
                    {
                        if (i != ControlNum && j != ControlNum && k != ControlNum)
                        {
                            Console.Write($"{i}{j}{k} ");
                        }
                    }
                }
            }

        }
    }
}