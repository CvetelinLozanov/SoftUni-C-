using System;
using System.Text;

namespace _03.Unicode_Characters
{
    class Program
    {

        static void Main(string[] args)
        {
            var word = Console.ReadLine();
            var convertedToUnicode = GetUnicodeString(word);
            Console.WriteLine(convertedToUnicode);

        }

        static string GetUnicodeString(string s)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in s)
            {
                sb.Append("\\u");
                sb.Append(String.Format("{0:x4}", (int)c));
            }
            return sb.ToString();
        }
    }
}