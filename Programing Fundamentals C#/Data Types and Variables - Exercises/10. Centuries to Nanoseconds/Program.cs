using System;
using System.Numerics;

namespace _10.Centuries_to_Nanoseconds
{
    class Program
    {
        static void Main(string[] args)
        {
            var centuries = int.Parse(Console.ReadLine());
            int years = centuries * 100;
            int days = (int)(years * 365.2422);
            int hours = days * 24;
            int minutes = hours * 60;
            ulong seconds = (ulong)minutes * 60;
            ulong milliSeconds = seconds * 1000;
            ulong microSeconds = milliSeconds * 1000;
            BigInteger nanoSeconds = (BigInteger)microSeconds * 1000;
            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {milliSeconds} milliseconds = {microSeconds} microseconds = {nanoSeconds} nanoseconds");
        }
    }
}