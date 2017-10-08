using System;
using System.Linq;

namespace _02.Manipulate_Array
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine()
                 .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                switch (command[0])
                {
                    case "Distinct":
                       input = input.Distinct().ToArray();
                        break;
                    case "Reverse":
                        ReverseTheArray(input);
                        break;
                    case "Replace":
                        int index = int.Parse(command[1]);
                        string word = command[2];
                        input[index] = word;
                        break;
                }

            }
            Console.WriteLine(String.Join(", ", input));
        }

        private static void ReverseTheArray(string[] input)
        {
            Array.Reverse(input);
        }
    }
}
