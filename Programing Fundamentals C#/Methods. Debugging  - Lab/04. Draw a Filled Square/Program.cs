using System;

namespace _04.Draw_a_Filled_Square
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            PrintDashes(number);
            for (int i = 0; i < number - 2; i++)
            {
                PrintMiddlePart(number);
                Console.WriteLine();
            }
            PrintDashes(number);
          
        }

        private static void PrintMiddlePart(int number)
        {
            Console.Write("-");
            for (int i = 1; i < number; i++)
            {
                Console.Write(@"\/");
            }
            Console.Write("-");
        }

        private static void PrintDashes(int number)
        {
            Console.WriteLine(new string('-', 2 * number));
        }
    }
}