using System;

namespace _03.Back_in_30_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            var hours = double.Parse(Console.ReadLine());
            var minutes = double.Parse(Console.ReadLine());
            var minutes1 = 0.0;
            minutes1 = minutes + 30;
            if (minutes1 >= 60)
            {

                ++hours;
                minutes1 %= 60;

            }
            if (hours >= 24)
            {
                hours -= 24;
            }
            if (minutes1 < 10)
            {
                Console.WriteLine($"{hours}:0{minutes1}");
            }
            else
            {
                Console.WriteLine($"{hours}:{minutes1}");
            }
        }
    }
}