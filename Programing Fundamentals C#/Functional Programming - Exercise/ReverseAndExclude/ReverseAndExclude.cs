using System;
using System.Linq;

namespace ReverseAndExclude
{
    class ReverseAndExclude
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int specialNum = int.Parse(Console.ReadLine());

            inputNumbers = removeNumbers(inputNumbers, specialNum);
            reverseArray(inputNumbers);
            print(inputNumbers);


        }
        public static Func<int[], int, int[]> removeNumbers = (numbers, specialNumber) =>
        {
            return numbers.Where(n => n % specialNumber != 0).ToArray();
        };

        public static Action<int[]> print = numbers =>
         {
             Console.WriteLine(String.Join(' ', numbers));
         };

        public static Action<int[]> reverseArray = numbers =>
         {
             Array.Reverse(numbers);
         };
    }
}
