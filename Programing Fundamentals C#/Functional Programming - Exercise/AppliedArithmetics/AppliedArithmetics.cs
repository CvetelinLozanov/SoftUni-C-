using System;
using System.Linq;

namespace AppliedArithmetics
{
    class AppliedArithmetics
    {
        static void Main(string[] args)
        {
            Func<int[], int[]> addOne = nums => nums.Select(n => n + 1).ToArray();
            Func<int[], int[]> multiplyByTwo = nums => nums.Select(n => n * 2).ToArray();
            Func<int[], int[]> subtractOne = nums => nums.Select(n => n - 1).ToArray();
            Action<int[]> print = nums => Console.WriteLine(String.Join(" ", nums));

            int[] inputNumbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string command = Console.ReadLine();
            while (command != "end")
            {
                if (command == "add")
                {
                    inputNumbers = addOne(inputNumbers);
                }
                else if (command == "subtract")
                {
                    inputNumbers = subtractOne(inputNumbers);
                }
                else if (command == "multilply")
                {
                    inputNumbers = multiplyByTwo(inputNumbers);
                }
                else if (command == "print")
                {
                    print(inputNumbers);
                }

                command = Console.ReadLine();
            }
        }
    }
}
