using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            var width = int.Parse(Console.ReadLine());
            var height = int.Parse(Console.ReadLine());
            var megaPixels = width * height / 1000000.0;
            Console.WriteLine(width + "x" + height + " => " + Math.Round(megaPixels, 1) + "MP");
        }
    }
}