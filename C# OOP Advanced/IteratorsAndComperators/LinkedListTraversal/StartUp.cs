using LinkedListTraversal.Models;
using System;

namespace LinkedListTraversal
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var linkedList = new LinkedList<int>();

            ExecuteCommands(linkedList);
            PrintResult(linkedList);
        }

        private static void PrintResult(LinkedList<int> linkedList)
        {
            Console.WriteLine(linkedList.Count);
            Console.WriteLine(string.Join(" ", linkedList));
        }

        private static void ExecuteCommands(LinkedList<int> linkedList)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                var command = Console.ReadLine().Split();
                var number = int.Parse(command[1]);

                switch (command[0])
                {
                    case "Add":
                        linkedList.Add(number);
                        break;
                    case "Remove":
                        linkedList.Remove(number);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
