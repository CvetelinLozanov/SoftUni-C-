using System;
using System.Linq;

namespace _09.Jump_Around
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var index = 0;
            var sum = 0;
            while (true)
            {
                int tempIndex = index;
                sum += numbers[index];
                index += numbers[index];
                if (index >= numbers.Length)
                {
                    index = tempIndex - numbers[tempIndex];
                    if (index < 0)
                    {
                        break;
                    }
                }
            }
            Console.WriteLine(sum);

        }
    }
}