using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _04.Hotel
{

    class Program
    {
        static void Main(string[] args)
        {
            var month = Console.ReadLine();
            var nights = int.Parse(Console.ReadLine());
            var studio = 0.0;
            var suite = 0.0;
            var double1 = 0.0;
            if (month == "May" || month == "October")
            {
                studio = 50 * nights;
                if (nights > 7)
                {
                    studio -= studio * 0.05;
                }                
                double1 = nights * 65.0;
                suite = nights * 75.0;
            }
            else if (month == "June" || month == "September")
            {
                studio = nights * 60.0;
                double1 = nights * 72.0;
                if (nights > 14)
                {
                    double1 -= double1 * 0.10;
                }
                suite = nights * 82.0;
            }
            else
            {
                studio = nights * 68.0;
                double1 = nights * 77.0;
                suite = nights * 89.0;
                if (nights > 14)
                {
                    suite -= suite * 0.15;
                }
            }
            if (nights > 7 && month == "September")
            {
                studio -= 60;
            }
            if (nights > 7 && month == "October")
            {
                studio -= 50 * 0.95;
            }
            Console.WriteLine("Studio: {0:f2} lv.", studio);
            Console.WriteLine($"Double: {double1:F2} lv.");
            Console.WriteLine($"Suite: {suite:F2} lv.");
        }
    }
}