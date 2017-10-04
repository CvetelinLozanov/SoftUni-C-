using System;
using System.Linq;

namespace _09.Extract_Middle_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            if (array.Length == 1)
            {
                Console.Write("{ " + array[0] + " }");
            }
            else if (array.Length % 2 == 0)
            {
                Console.Write("{ " + array[array.Length / 2 - 1] + ", " + array[array.Length / 2] + " }");
            }
            else if (array.Length % 2 == 1)
            {
                Console.Write("{ " + array[array.Length / 2 - 1] + ", " + array[array.Length / 2] + ", " + array[array.Length / 2 + 1] + " }");
            }
        }
    }
}