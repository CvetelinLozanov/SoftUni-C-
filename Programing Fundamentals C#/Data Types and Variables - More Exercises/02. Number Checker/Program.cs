using System;

namespace _02.Number_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var num = long.Parse(Console.ReadLine());
                Console.WriteLine("integer");
            }
            catch (Exception)
            {
                Console.WriteLine("floating-point");
            }
        }
    }
}