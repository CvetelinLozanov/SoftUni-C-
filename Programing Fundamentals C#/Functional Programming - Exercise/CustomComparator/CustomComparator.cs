using System;
using System.Linq;

namespace CustomComparator
{
    class CustomComparator
    {
        static void Main(string[] args)
        {
            Action<int[]> print = p => Console.WriteLine(String.Join(' ', p));

            Func<int, int, int> sortFunc = (a, b) =>
            (a % 2 == 0 && b % 2 != 0) ? -1 :
            (a % 2 != 0 && b % 2 == 0) ? 1 :
            a.CompareTo(b);

            int[] inputNums = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Array.Sort(inputNums, new Comparison<int>(sortFunc));

            print(inputNums);
        }
    }
}
