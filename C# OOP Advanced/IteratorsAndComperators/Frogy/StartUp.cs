namespace Frogy
{
    using System;
    using System.Linq;
    using Frogy.Model;

    class StartUp
    {
        static void Main(string[] args)
        {
            int[] stones = Console.ReadLine()
                 .Split(',', StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            Lake lake = new Lake(stones);

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
