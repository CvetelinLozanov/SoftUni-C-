using System;

namespace _12.Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var sum = 0d;
            var maxValue = 0d;
            var biggestKeg = string.Empty;
            for (int i = 1; i <= n; i++)
            {
                var model = Console.ReadLine();
                //var model1 = Console.ReadLine();
                var radius = double.Parse(Console.ReadLine());
                var height = int.Parse(Console.ReadLine());
                sum = Math.PI * Math.Pow(radius, 2) * height;
                if (sum > maxValue)
                {
                    maxValue = sum;
                    biggestKeg = model;

                }
            }
            Console.WriteLine(biggestKeg);
        }
    }
}