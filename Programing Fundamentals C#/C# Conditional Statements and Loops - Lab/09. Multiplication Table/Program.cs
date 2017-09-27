using System;

namespace _09.Multiplication_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var cnt = 1;
            while (cnt <= 10)
            {
                Console.WriteLine($"{n} X {cnt} = {n * cnt}");
                cnt++;
            }
        }
    }
}