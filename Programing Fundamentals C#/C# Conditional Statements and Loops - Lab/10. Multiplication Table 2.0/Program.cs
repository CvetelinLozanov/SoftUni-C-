using System;

namespace _10.Multiplication_Table_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var cnt = int.Parse(Console.ReadLine());
            if (cnt <= 10)
            {
                while (cnt <= 10)
                {
                    Console.WriteLine($"{n} X {cnt} = {n * cnt}");
                    cnt++;
                }
            }
            else
            {
                Console.WriteLine($"{n} X {cnt} = {n * cnt}");
            }
        }
    }
}