using System;
using System.Linq;
using System.Collections.Generic;

namespace _06.Byte_Flip
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            input.RemoveAll(i => i.Length != 2);

            for (int i = 0; i < input.Count; i++)
            {
                char[] number = input[i].ToCharArray();
                Array.Reverse(number);

                input.RemoveAt(i);
                input.Insert(i, new string(number));
            }

            input.Reverse();

            foreach (var num in input)
            {
                Console.Write(Convert.ToChar(Convert.ToInt32(num, 16)));
            }
            Console.WriteLine();
        }
    }
}