using System;

namespace _05.Boolean_Variable
{
    class Program
    {
        static void Main(string[] args)
        {
            var string1 = Console.ReadLine();
            bool trueOrFalse = Convert.ToBoolean(string1);
            if (trueOrFalse == true)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}