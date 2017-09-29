using System;

namespace _05.Temperature_Conversion
{
    class Program
    {
        static void Main(string[] args)
        {
          
            double fahrenheit = double.Parse(Console.ReadLine());
            double celsius = ConvertFahrenheitToCelsius(fahrenheit);
            Console.WriteLine($"{celsius:F2}");
        }

        private static double ConvertFahrenheitToCelsius(double fahrenheit)
        {
            double celsius = (fahrenheit - 32) * 5 / 9;
            return celsius;
        }
    }
}