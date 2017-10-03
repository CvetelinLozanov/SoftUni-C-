using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _11.Geometry_Calculator
{

    class Program
    {
        static void Main(string[] args)
        {

            var parameter = Console.ReadLine();
            var area = AreaOfFigures(parameter);
            Console.WriteLine($"{area:F2}");

        }

        static double AreaOfFigures(string parameter)
        {
            double area = 0.0;
            switch (parameter)
            {
                case "triangle":
                    var a = double.Parse(Console.ReadLine());
                    var ha = double.Parse(Console.ReadLine());
                    area = AreaOfTriangle(a, ha);
                    break;
                case "rectangle":
                    a = double.Parse(Console.ReadLine());
                    var b = double.Parse(Console.ReadLine());
                    area = AreaOfRectangle(a, b);
                    break;
                case "square":
                    a = double.Parse(Console.ReadLine());
                    area = AreaOfSquare(a);
                    break;
                case "circle":
                    a = double.Parse(Console.ReadLine());
                    area = AreaOfCircle(a);
                    break;
            }
            return area;
        }

        static double AreaOfCircle(double a)
        {
            return Math.PI * Math.Pow(a, 2);
        }

        static double AreaOfSquare(double a)
        {
            return Math.Pow(a, 2);
        }

        static double AreaOfRectangle(double a, double b)
        {
            return a * b;
        }

        static double AreaOfTriangle(double a, double ha)
        {
            return (a * ha) / 2;
        }
    }
}