using System;

namespace _14.Integer_to_Hex_and_Binary
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            var binary = Convert.ToString(number, 2);
            var hex = Convert.ToString(number, 16);
            Console.WriteLine(hex.ToUpper());
            Console.WriteLine(binary);

        }
    }
}