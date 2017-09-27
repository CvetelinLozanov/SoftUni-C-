using System;

namespace _05.Weather_Forecast
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var num = long.Parse(Console.ReadLine());
                if (num >= sbyte.MinValue && num <= sbyte.MaxValue)
                {
                    Console.WriteLine("Sunny");
                }
                else if (num >= int.MinValue && num <= int.MaxValue)
                {
                    Console.WriteLine("Cloudy");
                }
                else if (num >= long.MinValue && num <= long.MaxValue)
                {
                    Console.WriteLine("Windy");
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Rainy");
            }
        }
    }

}