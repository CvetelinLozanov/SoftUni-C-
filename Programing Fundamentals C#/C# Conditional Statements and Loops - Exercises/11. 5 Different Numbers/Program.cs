using System;

namespace _11._5_Different_Numbers
{

    class Program
    {
        static void Main(string[] args)
        {
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());
            var diff = b - a;

            if (diff < 5)
            {
                Console.WriteLine("No");
            }
            for (int i = a; i < b; i++)
            {
                for (int j = a; j < b; j++)
                {
                    for (int n3 = a; n3 < b; n3++)
                    {
                        for (int n4 = a; n4 < b; n4++)
                        {
                            for (int n5 = a; n5 <= b; n5++)
                            {

                                if (a <= i && i < j && j < n3 && n3 < n4 && n4 < n5 && n5 <= b)
                                {
                                    Console.WriteLine($"{i} {j} {n3} {n4} {n5}");
                                }

                            }
                        }
                    }

                }

            }
        }
    }

}