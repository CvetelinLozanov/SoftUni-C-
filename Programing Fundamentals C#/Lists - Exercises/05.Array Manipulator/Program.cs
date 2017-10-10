using System;
using System.Linq;
using System.Collections.Generic;

namespace _05.Array_Manipulator
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            var command = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            while (command[0] != "print")
            {
                switch (command[0])
                {
                    case "add":
                        int index = int.Parse(command[1]);
                        int item = int.Parse(command[2]);
                        numbers.Insert(index, item);
                        break;
                    case "addMany":
                        var nums = new int[command.Length - 2];
                        int indexForMany = int.Parse(command[1]);
                        for (int i = 0; i < nums.Length; i++)
                        {
                            nums[i] = int.Parse(command[i + 2]);
                        }
                        numbers.InsertRange(indexForMany, nums);
                        break;
                    case "contains":
                        int element = int.Parse(command[1]);
                        if (!numbers.Contains(element))
                        {
                            Console.WriteLine("-1");
                        }
                        else
                        {
                            for (int i = 0; i < numbers.Count; i++)
                            {
                                if (element == numbers[i])
                                {
                                    Console.WriteLine(i);
                                    break;
                                }
                            }
                        }
                        break;
                    case "remove":
                        int indexForRemove = int.Parse(command[1]);
                        numbers.RemoveAt(indexForRemove);
                        break;
                    case "shift":
                        int position = int.Parse(command[1]);
                        for (int i = 0; i < position; i++)
                        {
                            int temp = numbers[0];
                            for (int j = 1; j < numbers.Count; j++)
                            {
                                numbers[j - 1] = numbers[j];
                            }
                            numbers[numbers.Count - 1] = temp;
                        }
                        break;
                    case "sumPairs":
                        var pairsSum = new List<int>();
                        for (int i = 0; i < numbers.Count; i += 2)
                        {
                            var currentelement = numbers[i];
                            var nextelement = 0;
                            if (i < numbers.Count - 1)
                            {
                                nextelement = numbers[i + 1];
                            }
                            var elementsSum = currentelement + nextelement;

                            pairsSum.Add(elementsSum);
                        }
                        numbers = pairsSum;
                        break;
                }
                command = Console.ReadLine()
               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .ToArray();
            }
            Console.WriteLine($"[{String.Join(", ", numbers)}]");
        }
    }
}