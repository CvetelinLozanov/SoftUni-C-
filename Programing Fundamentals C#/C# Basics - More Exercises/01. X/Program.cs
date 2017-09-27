using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var cnt = 0;
            for (int i = 0; i < N / 2; i++)
            {
                Console.WriteLine("{1}x{0}x{1}", new string(' ', N - 2 - cnt), new string(' ', i));
                cnt += 2;
            }
            cnt = 1;
            Console.WriteLine("{0}x{0}", new string(' ', N / 2));
            for (int i = N / 2 - 1; i >= 0; i--)
            {
                Console.WriteLine("{0}x{1}x{0}", new string(' ', i), new string(' ', cnt));
                cnt += 2;
            }
        }
    }
}
