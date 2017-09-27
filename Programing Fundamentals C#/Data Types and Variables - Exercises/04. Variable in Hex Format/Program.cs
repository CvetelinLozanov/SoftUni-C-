using System;

namespace _04.Variable_in_Hex_Format
{
    class Program
    {
        static void Main(string[] args)
        {
            var hexNum = Console.ReadLine();
            int num = Convert.ToInt32(hexNum, 16);
            Console.WriteLine(num);
        }
    }
}