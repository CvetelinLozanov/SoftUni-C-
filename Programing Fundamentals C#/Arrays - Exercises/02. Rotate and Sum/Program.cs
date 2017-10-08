using System;
using System.Linq;

namespace _02.Rotate_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int numberOfRotates = int.Parse(Console.ReadLine());
            int[] sumArr = new int[numbers.Length];
            for (int i = 0; i < numberOfRotates; i++)
            {
                RotateArray(numbers);
                for (int j = 0; j < numbers.Length; j++)
                {
                    sumArr[j] += numbers[j];
                }
            }
            Console.WriteLine(String.Join(" ", sumArr));
        }

        private static void RotateArray(int[] numbers)
        {
            int lastElement = numbers[numbers.Length - 1];
            for (int i = numbers.Length - 1; i > 0; i--)
            {
                numbers[i] = numbers[i - 1];
            }
            numbers[0] = lastElement;
        }
    }
}