namespace CustomStack
{
    using System;
    using System.Linq;
    using CustomStack.SoftUniStack;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(new char[] { ' ', ',' },
                StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .ToArray();

            SoftUniStack<string> stack = new SoftUniStack<string>();

            foreach (var str in input)
            {
                stack.Push(str);
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                switch (command)
                {
                    case "Pop":
                        try
                        {
                            stack.Pop();
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    
                    default:
                        string element = command.Split()[1];
                        stack.Push(element);
                        break;
                }
                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine, stack));
            Console.WriteLine(string.Join(Environment.NewLine, stack));
        }
    }
}
