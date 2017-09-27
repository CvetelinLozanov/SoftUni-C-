using System;

namespace _13.Decrypting_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            var key = int.Parse(Console.ReadLine());
            var n = int.Parse(Console.ReadLine());
            var wordNumber = 0;
            var word = string.Empty;
            for (int i = 1; i <= n; i++)
            {
                var letters = char.Parse(Console.ReadLine());
                wordNumber = letters + key;
                word += (char)wordNumber;
            }
            Console.WriteLine(word);
        }
    }
}