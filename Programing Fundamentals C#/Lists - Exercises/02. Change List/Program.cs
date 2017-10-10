using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.Change_List
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList();
            string command = Console.ReadLine();
            while (true)
            {
                var commands = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                string token = commands[0];
                switch (token)
                {
                    case "Delete":
                        long element = long.Parse(commands[1]);
                        while (numbers.Contains(element))
                        {
                            numbers.Remove(element);
                        }
                        break;
                    case "Insert":
                        long elementForInsert = long.Parse(commands[1]);
                        int index = int.Parse(commands[2]);
                        numbers.Insert(index, elementForInsert);
                        break;
                }
                if (commands[0] == "Odd")
                {
                    foreach (var num in numbers)
                    {
                        if (num % 2 == 1)
                        {
                            Console.Write(num + " ");
                        }
                    }
                    return;
                }
                else if (commands[0] == "Even")
                {
                    foreach (var num in numbers)
                    {
                        if (num % 2 == 0)
                        {
                            Console.Write(num + " ");
                        }
                    }
                    return;
                }
                command = Console.ReadLine();
               
            }
           
        }
    }
}