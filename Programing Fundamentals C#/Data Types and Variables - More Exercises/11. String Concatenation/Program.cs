using System;

namespace _11.String_Concatenation
{
    class Program
    {
        static void Main(string[] args)
        {
            var delimiter = char.Parse(Console.ReadLine());
            var condition = Console.ReadLine().ToLower().Trim();
            var message = string.Empty;
            var result = 0;
            if (condition == "odd")
            {
                result = 1;
            }
            var n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                var tempString = Console.ReadLine();
                if (i % 2 == result)
                {
                    message += tempString + delimiter;
                }
            }
            Console.WriteLine(message.Substring(0, message.Length - 1));
        }
    }
}