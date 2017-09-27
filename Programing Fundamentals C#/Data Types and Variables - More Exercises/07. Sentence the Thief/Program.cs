using System;

namespace _07.Sentence_the_Thief
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
            if (idMin > 0)
            {
                double prisonerYears = Math.Ceiling((double)idMin / sbyte.MaxValue);

                if (prisonerYears <= 9)
                {
                    Console.WriteLine($"Prisoner with id {idMin} is sentenced to {prisonerYears} year");
                }
                else
                {
                    Console.WriteLine($"Prisoner with id {idMin} is sentenced to {prisonerYears} years");
                }

            }
            else if (idMin < 0)
            {
                double prisonerYears = Math.Ceiling((double)idMin / sbyte.MinValue);

                if (prisonerYears <= 9)
                {
                    Console.WriteLine($"Prisoner with id {idMin} is sentenced to {prisonerYears} year");
                }
                else
                {
                    Console.WriteLine($"Prisoner with id {idMin} is sentenced to {prisonerYears} years");
                }


            }

        }
    }
}