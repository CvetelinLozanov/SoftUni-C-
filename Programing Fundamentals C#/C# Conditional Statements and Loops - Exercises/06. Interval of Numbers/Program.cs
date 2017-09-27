using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _06.Interval_of_Numbers
{

    class Program
    {
        static void Main(string[] args)
        {
            var startNum = int.Parse(Console.ReadLine());
            var endNum = int.Parse(Console.ReadLine());
            if (startNum <= endNum)
            {
                while (startNum <= endNum)
                {
                    Console.WriteLine(startNum);
                    startNum++;
                }
            }
            else
            {
                while (endNum <= startNum)
                {
                    Console.WriteLine(endNum);
                    endNum++;
                }

            }
        }
    }

}