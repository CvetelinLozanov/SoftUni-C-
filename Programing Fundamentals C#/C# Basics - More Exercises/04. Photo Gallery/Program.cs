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
            var photoNum = int.Parse(Console.ReadLine());
            var day = int.Parse(Console.ReadLine());
            var month = int.Parse(Console.ReadLine());
            var year = int.Parse(Console.ReadLine());
            var hours = int.Parse(Console.ReadLine());
            var minutes = int.Parse(Console.ReadLine());
            var size = double.Parse(Console.ReadLine());
            var width = int.Parse(Console.ReadLine());
            var height = int.Parse(Console.ReadLine());


            Console.WriteLine($"Name: DSC_{photoNum:D4}.jpg");
            Console.WriteLine("Date Taken: {0:d2}/{1:d2}/{2} {3:d2}:{4:d2}",
               day, month, year, hours, minutes);
            if (size < 1000)
            {
                Console.WriteLine($"Size: {size}B");
            }
            else if (size < 1000000)
            {
                size /= 1000.0;
                Console.WriteLine($"Size: {size}KB");
            }
            else
            {
                size /= 1000000.0;
                Console.WriteLine($"Size: {size}MB");
            }
            if (width > height)
            {
                Console.WriteLine($"Resolution: {width}x{height} (landscape)");
            }
            else if (height > width)
            {
                Console.WriteLine($"Resolution: {width}x{height} (portrait)");
            }
            else if (height == width)
            {
                Console.WriteLine($"Resolution: {width}x{height} (square)");
            }

        }
    }
}