using System;

namespace _05.Compare_Char_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = Console.ReadLine().Split(' ');
            string[] arr2 = Console.ReadLine().Split(' ');
            int minLength = Math.Min(arr1.Length, arr2.Length);
            for (int i = 0; i < minLength; i++)
            {
                if (arr1[i].CompareTo(arr2[i]) < 0)
                {
                    Console.WriteLine(String.Join("", arr1));
                    Console.WriteLine(String.Join("", arr2));
                    return;
                }
                else if (arr2[i].CompareTo(arr1[i]) < 0)
                {
                    Console.WriteLine(String.Join("", arr2));
                    Console.WriteLine(String.Join("", arr1));
                    return;
                }
                else if (arr1[i].CompareTo(arr2[i]) == 0 && arr1.Length == arr2.Length)
                {
                    foreach (var letter in arr1)
                    {
                        Console.Write(letter);
                    }
                    Console.WriteLine();
                    foreach (var letter in arr2)
                    {
                        Console.Write(letter);
                    }
                    Console.WriteLine();
                    return;
                }
                else if (arr1[i].CompareTo(arr2[i]) == 0 && arr1.Length > arr2.Length)
                {
                    foreach (var letter in arr2)
                    {
                        Console.Write(letter);
                    }
                    Console.WriteLine();
                    foreach (var letter in arr1)
                    {
                        Console.Write(letter);
                    }
                    Console.WriteLine();
                    return;

                }
                else
                {
                    foreach (var letter in arr1)
                    {
                        Console.Write(letter);
                    }
                    Console.WriteLine();
                    foreach (var letter in arr2)
                    {
                        Console.Write(letter);
                    }
                    Console.WriteLine();
                    return;
                }
            }
        }
    }
}