using System;
using System.Linq;

namespace _03.Safe_Manipulation
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            string[] command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            while (command[0] != "END")
            {
                switch (command[0])
                {
                    case "Distinct":
                        input = input.Distinct().ToArray();
                        break;
                    case "Reverse":
                        Array.Reverse(input); 
                        break;
                    case "Replace":
                        string newWord = command[2];
                        int index = int.Parse(command[1]);
                        if (index >= input.Length || index < 0)
                        {
                            Console.WriteLine("Invalid input!");
                        }
                        else
                        {
                            input[index] = newWord;
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }
                command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine(String.Join(", ", input));
        }
    }
}