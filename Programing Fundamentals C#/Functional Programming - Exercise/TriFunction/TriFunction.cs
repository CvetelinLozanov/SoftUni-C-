using System;
using System.Linq;

namespace TriFunction
{
    class TriFunction
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string[] inputNames = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Action<string> print = p => Console.WriteLine(p);

            Func<string, int, bool> isEqualSum = (name, totalSum) => name.Sum(x => x) >= totalSum;

            Func<string[], Func<string, int, bool>, string> firstNameFunc = (names, isEqualAsciiSum) =>
                names.FirstOrDefault(x => isEqualSum(x, num));

            var result = firstNameFunc(inputNames, isEqualSum);

            print(result);

        }
    }
}
