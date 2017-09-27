using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _10.Triangle_of_Numbers
{

    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var cnt = 0;
            for (int i = 1; i <= n; i++)
            {
                cnt++;
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(cnt + " ");
                }
                Console.WriteLine();
            }
        }
    }

}