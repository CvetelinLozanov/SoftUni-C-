using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace _04.Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main()
        {
            string[] input = File.ReadAllText("input.txt").Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int bestLenght = 1;
            int lenght = 1;
            string element = input[0];
            File.Delete("output.txt");
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == input[i - 1])
                {
                    lenght++;
                    if (lenght > bestLenght)
                    {
                        bestLenght = lenght;
                        element = input[i];
                    }
                }
                else
                {
                    lenght = 1;
                }
            }
            for (int i = 0; i < bestLenght; i++)
            {
                File.AppendAllText("output.txt", element + " ");
            }
        }
    }
}