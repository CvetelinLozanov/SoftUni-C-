using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Choose_a_Drink_2._0
{

    class Program
    {
        static void Main(string[] args)
        {
            var profession = Console.ReadLine();
            var number = double.Parse(Console.ReadLine());
            if (profession == "Athlete")
            {
                Console.WriteLine("The {1} has to pay {0:f2}.", number * 0.70, profession);
            }
            else if (profession == "Businessman" || profession == "Businesswoman")
            {
                Console.WriteLine($"The {profession} has to pay {number * 1.00:F2}.");
            }
            else if (profession == "SoftUni Student")
            {
                Console.WriteLine($"The {profession} has to pay {number * 1.70:F2}.");
            }
            else
            {
                Console.WriteLine($"The {profession} has to pay {number * 1.20:F2}.");
            }
        }
    }

}