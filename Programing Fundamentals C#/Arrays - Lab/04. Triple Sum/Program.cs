using System;
using System.Linq;

namespace _04.Triple_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            bool contains = false;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (j == i) continue;
                    int temp = arr[i] + arr[j];
                    if (arr.Contains(temp))
                    {
                        Console.WriteLine($"{arr[i]} + {arr[j]} == {temp}");
                        contains = true;
                    }
                }
            }
            if (!contains)
            {
                Console.WriteLine("No");
            }
        }
    }
}