using ListIterator.Models;
using System;
using System.Linq;

namespace ListIterator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .ToArray();
            CustomList<string> list = new CustomList<string>(input);

            string command = Console.ReadLine();

            while (command != "END")
            {
                switch (command)
                {
                    case "Move":
                        Console.WriteLine(list.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(list.HasNext());
                        break;
                    case "Print":
                        try
                        {
                            list.Print();
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                      
                        break;

                    case "PrintAll":
                        list.PrintAll();
                        Console.WriteLine();
                        break;
                }
                command = Console.ReadLine();
            }
        }
    }
}
