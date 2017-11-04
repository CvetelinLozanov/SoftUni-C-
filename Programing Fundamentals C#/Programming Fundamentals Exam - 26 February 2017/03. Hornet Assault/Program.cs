using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.Hornet_Assault
{
    class Program
    {
        static void Main()
        {
            long[] beehives = Console.ReadLine()
                  .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                  .Select(long.Parse)
                  .ToArray();
            List<long> hornets = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList();
            List<long> aliveBees = new List<long>();
            foreach (var bee in beehives)
            {
                long power = hornets.Sum();
                if (hornets.Count == 0)
                {
                    aliveBees.Add(bee);
                    continue;
                }
                if (power >= bee)
                {
                    if (power == bee)
                    {
                        hornets.RemoveAt(0);
                    }
                }
                else
                {
                    aliveBees.Add(bee - power);
                    hornets.RemoveAt(0);
                }
            }
            if (aliveBees.Count != 0)
            {
                Console.WriteLine(String.Join(" ", aliveBees));
            }
            else
            {
                Console.WriteLine(String.Join(" ", hornets));
            }
        }
    }
}