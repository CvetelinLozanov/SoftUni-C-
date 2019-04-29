using System;

namespace CustomList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SoftuniList<string> softuniList = new SoftuniList<string>();
                      
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] inputArgs = input.Split();

                string command = inputArgs[0];

                string element = string.Empty;

                switch (command)
                {
                    case "Add":
                        element = inputArgs[1];
                        softuniList.Add(element);
                        break;
                    case "Remove":
                        int index = int.Parse(inputArgs[1]);
                        softuniList.Remove(index);
                        break;
                    case "Contains":
                        element = inputArgs[1];
                        Console.WriteLine(softuniList.Contains(element));
                        break;
                    case "Swap":
                        int firstIndex = int.Parse(inputArgs[1]);
                        int secondIndex = int.Parse(inputArgs[2]);
                        softuniList.Swap(firstIndex, secondIndex);
                        break;
                    case "Greater":
                        element = inputArgs[1];
                        Console.WriteLine(softuniList.CountGreaterThan(element));
                        break;
                    case "Max":
                        Console.WriteLine(softuniList.Max());
                        break;
                    case "Min":
                        Console.WriteLine(softuniList.Min());
                        break;
                    case "Print":
                        Console.WriteLine(softuniList);
                        break;
                    case "Sort":
                        softuniList.Sort();
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}
