using System;

namespace _06.Catch_the_Thief
{
    class Program
    {
        static void Main(string[] args)
        {
            var thiefID = Console.ReadLine();
            long idMax = 0;

            switch (thiefID)
            {
                case "sbyte":
                    idMax = sbyte.MaxValue;
                    break;
                case "int":
                    idMax = int.MaxValue;
                    break;
                case "long":
                    idMax = long.MaxValue;
                    break;
            }
            long idMin = long.MinValue;
            var n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                long id = long.Parse(Console.ReadLine());
                if (id >= idMin && id <= idMax)
                {
                    idMin = id;
                }
            }
            Console.WriteLine(idMin);
        }
    }
}