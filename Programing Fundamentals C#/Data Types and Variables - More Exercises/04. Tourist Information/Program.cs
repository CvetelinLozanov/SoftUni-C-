using System;

namespace _04.Tourist_Information
{
    class Program
    {
        static void Main(string[] args)
        {
            var value = Console.ReadLine();
            var imperialUnit = double.Parse(Console.ReadLine());

            double finalResult = 0.0;
            switch (value)
            {
                case "miles":
                    finalResult = imperialUnit * 1.6;
                    Console.WriteLine($"{imperialUnit} {value} = {finalResult:F2} kilometers");
                    break;
                case "inches":
                    finalResult = imperialUnit * 2.54;
                    Console.WriteLine($"{imperialUnit} {value} = {finalResult:F2} centimeters");
                    break;
                case "feet":
                    finalResult = imperialUnit * 30.0;
                    Console.WriteLine($"{imperialUnit} {value} = {finalResult:F2} centimeters");
                    break;
                case "yards":
                    finalResult = imperialUnit * 0.91;
                    Console.WriteLine($"{imperialUnit} {value} = {finalResult:F2} meters");
                    break;
                case "gallons":
                    finalResult = imperialUnit * 3.8;
                    Console.WriteLine($"{imperialUnit} {value} = {finalResult:F2} liters");
                    break;
            }
        }
    }

}