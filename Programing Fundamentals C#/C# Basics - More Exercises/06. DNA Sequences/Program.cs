using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            var sum = int.Parse(Console.ReadLine());
            var cnt = 0;
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    for (int k = 1; k <= 4; k++)
                    {
                        cnt++;
                        if (i + j + k >= sum)
                        {
                            Console.Write("O" + ("" + i + j + k).Replace('1', 'A').Replace('2', 'C').Replace('3', 'G').Replace('4', 'T') + "O ");
                        }
                        else
                        {
                            Console.Write("X" + ("" + i + j + k).Replace('1', 'A').Replace('2', 'C').Replace('3', 'G').Replace('4', 'T') + "X ");
                        }
                        if (cnt % 4 == 0)
                        {
                            Console.WriteLine();
                        }
                    }
                }
            }
        }
    }
}