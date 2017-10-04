using System;

namespace _02.Reverse_Array_of_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                int numbers = int.Parse(Console.ReadLine());
                arr[i] = numbers;
            }
            int[] reversedNumbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                reversedNumbers[arr.Length - 1 - i] = arr[i];
            }
            Console.WriteLine(String.Join(" ", reversedNumbers));
        }
    }
}