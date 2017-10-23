using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.Poke_Mon
{
    class Program
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            byte Y = byte.Parse(Console.ReadLine());
           
            double divided = N / 2.0;            
            int cnt = 0;
            while (N >= M)
            {
                N -= M;
                cnt++;
                if (N == divided && Y > 0)
                {
                    if (N / Y >= 0)
                    {
                        N /= Y;
                    }                   
                   
                }                
            }
            Console.WriteLine(N);
            Console.WriteLine(cnt);
        }
    }
}