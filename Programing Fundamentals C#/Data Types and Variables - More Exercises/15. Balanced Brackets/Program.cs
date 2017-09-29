using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.Balanced_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var brackets = 0;

            for (int i = 1; i <= n; i++)
            {
                var str = Console.ReadLine();

                if (str == "(")
                    brackets++;
                if (str == ")")
                    brackets--;
                if (str == "(" && i == n)
                {
                    Console.WriteLine("UNBALANCED");
                    return;
                }
            }

            if (brackets == 0)
                Console.WriteLine("BALANCED");
            else if (brackets < 0 || brackets > 0)
                Console.WriteLine("UNBALANCED");
        }
    }
}