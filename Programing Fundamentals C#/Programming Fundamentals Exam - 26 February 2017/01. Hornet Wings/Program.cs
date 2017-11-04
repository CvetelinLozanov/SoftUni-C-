using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.Hornet_Wings
{
    class Program
    {
        static void Main()
        {
            int wingFlaps = int.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            int endurance = int.Parse(Console.ReadLine());
            double meters = (wingFlaps / 1000.0) * distance;
            double flapsForSeconds = wingFlaps / 100.0;
            double rest = (wingFlaps / endurance) * 5;
            double sumSeconds = rest + flapsForSeconds;
            Console.WriteLine($"{meters:F2} m.");
            Console.WriteLine($"{sumSeconds} s.");
        }
    }
}