using System;
using System.Linq;

namespace _08.Most_Frequent_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            ushort[] numbers = Console.ReadLine()
                 .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(ushort.Parse)
                 .ToArray();
            int counter = 0;
            int bestLength = 0;
            ushort mostFrequentNumber = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (numbers[i] == numbers[j])
                    {
                        counter++;
                        if (counter > bestLength)
                        {
                            bestLength = counter;
                            mostFrequentNumber = numbers[j];
                        }
                    }
                    else
                    {
                        counter = 0;
                    }

                }
            }
            Console.WriteLine(mostFrequentNumber);
        }
    }
}