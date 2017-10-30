using System;
using System.Linq;

namespace _02.Icarus
{
    class Program
    {
        static void Main()
        {
            int[] plane = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int initialDmg = 1;
            int startIndex = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            while (command != "Supernova")
            {
                string[] tokens = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string position = tokens[0];
                int indexToMove = int.Parse(tokens[1]);            
               
                if (position == "left" )
                {
                    startIndex -= 1;
                    for (int i = 0; i < indexToMove; i++)
                    {
                        if (position == "left" && startIndex < 0)
                        {
                            startIndex = plane.Length - 1;
                            initialDmg++;
                        }
                      
                        plane[startIndex--] -= initialDmg;
                    }
                    startIndex += 1;
                }
                else if (position == "right")
                {
                    startIndex += 1;
                    for (int i = 0; i < indexToMove; i++)
                    {
                        
                         if (position == "right" && startIndex > plane.Length - 1)
                        {
                            startIndex = 0;
                            initialDmg++;
                        }
                        plane[startIndex++] -= initialDmg;
                    }
                    startIndex -= 1;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", plane));
        }
    }
}