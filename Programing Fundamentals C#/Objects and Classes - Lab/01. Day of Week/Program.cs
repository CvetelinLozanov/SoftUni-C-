using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;

namespace _01.Day_of_Week
{
    class Program
    {
        static void Main()
        {
            string date = Console.ReadLine();
            DateTime myDate = DateTime.ParseExact(date, "d-M-yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine(myDate.DayOfWeek);
        }
    }
}