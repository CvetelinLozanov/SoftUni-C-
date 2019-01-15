using System;

namespace KnightsOfHonor
{
    class KnightsOfHonor
    {
        static void Main(string[] args)
        {
            Action<string[]> print = names => Console.WriteLine("Sir " + string.Join("\nSir ", names));
            string[] inputNames = Console.ReadLine()
                 .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            print(inputNames);
        }
    }
}
