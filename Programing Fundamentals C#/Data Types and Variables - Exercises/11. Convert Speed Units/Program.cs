using System;

namespace _11.Convert_Speed_Units
{
    class Program
    {
        static void Main(string[] args)
        {
            var meters = int.Parse(Console.ReadLine());
            var hour = float.Parse(Console.ReadLine());
            var minutes = float.Parse(Console.ReadLine());
            var second = float.Parse(Console.ReadLine());
            //1 mile = 1609 meters
            float hoursToMin = hour * 60f;
            float minutesToSec = hoursToMin * 60f;
            float minutesToSeconds = minutes * 60f;
            float sumSeconds = minutesToSec + minutesToSeconds + second;
            Console.WriteLine(meters / sumSeconds);
            float secondsToMinutes = second / 60f;
            float minsToHours = secondsToMinutes / 60f;
            float minutesToHours = minutes / 60f;
            float sumHours = minsToHours + minutesToHours + hour;
            float km = meters / 1000f;
            Console.WriteLine(km / sumHours);
            float miles = meters / 1609f;
            Console.WriteLine(miles / sumHours);
        }
    }
}