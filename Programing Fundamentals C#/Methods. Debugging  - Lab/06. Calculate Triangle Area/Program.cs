using System;

namespace _06.Calculate_Triangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double triangleArea = CalculateTriangleArea(width, height);
            Console.WriteLine(triangleArea);
        }

        private static double CalculateTriangleArea(double width, double height)
        {
            return width * height / 2;
        }
    }
}