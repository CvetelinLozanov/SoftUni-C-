using System;
using System.Collections.Generic;

namespace _07.Multiply_big_number
{
    class Program
    {
        static void Main()
        {
            var input1 = Console.ReadLine().TrimStart(new char[] { '0' });
            var input2 = int.Parse(Console.ReadLine());

            if (input2 == 0)
            {
                Console.WriteLine(0);
                return;
            }


            var output = new List<int>();
            var extra = 0;

            for (int i = input1.Length - 1; i >= 0; i--)
            {
                var placeHolder = 0;

                placeHolder = int.Parse(input1[i].ToString()) * input2;

                if (extra > 0)
                {
                    placeHolder += extra;
                    extra = 0;
                }

                if (placeHolder > 9 && i > 0)
                {
                    output.Add(placeHolder % 10);
                    extra = Convert.ToInt32(placeHolder.ToString().Substring(0, 1));
                }
                else
                {
                    output.Add(placeHolder);
                }
            }

            output.Reverse();
            Console.WriteLine(string.Join("", output));
        }
    }
}