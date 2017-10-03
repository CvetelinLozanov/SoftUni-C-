
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Cube_Properties
{

    class Program
    {
        static void Main(string[] args)
        {
            var n = double.Parse(Console.ReadLine());
            var parameter = Console.ReadLine();
            double finalResult = PrintParameter(n, parameter);
            Console.WriteLine($"{finalResult:F2}");
        }

        static double PrintParameter(double n, string parameter)
        {
            var finalResult = 0.0;
            switch (parameter)
            {
                case "face":
                    finalResult = Math.Sqrt(2 * Math.Pow(n, 2));
                    break;
                case "space":
                    finalResult = Math.Sqrt(3 * Math.Pow(n, 2));
                    break;
                case "volume":
                    finalResult = Math.Pow(n, 3);
                    break;
                case "area":
                    finalResult = 6 * Math.Pow(n, 2);
                    break;
            }
            return finalResult;
        }
    }
}