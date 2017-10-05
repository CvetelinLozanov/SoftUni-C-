using System;
using System.Linq;

namespace _03.Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int k = numbers.Length / 4;         
            int[] firstArr = new int[k];
            int[] middleArr = new int[2 * k];
            int[] lastArr = new int[k];
            int[] resultArr = new int[2 * k];
            for (int i = 0; i < k; i++)
            {

            }
        }
    }
}