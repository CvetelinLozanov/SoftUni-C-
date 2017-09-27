using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            var bpm = int.Parse(Console.ReadLine());
            var beats = int.Parse(Console.ReadLine());
            double bars = Math.Round(beats / 4.0, 1);
            double secondsForBeat = 60.0 / bpm;
            double totalSeconds = beats * secondsForBeat;
            int minutes = (int)totalSeconds / 60;
            int seconds = (int)totalSeconds % 60;
            ;
            Console.WriteLine($"{bars} bars - {minutes}m {seconds}s");
        }
    }
}