using System;

namespace _14.Boat_Simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstBoat = char.Parse(Console.ReadLine());
            var secondBoat = char.Parse(Console.ReadLine());
            var n = int.Parse(Console.ReadLine());
            var firstBoatTiles = 0;
            var secondBoatTiles = 0;
            int firstBoatCopy = firstBoat;
            int secondBoatCopy = secondBoat;
            for (int i = 1; i <= n; i++)
            {
                var command = Console.ReadLine();
                if (command == "UPGRADE")
                {
                    firstBoatCopy = firstBoatCopy + 3;
                    secondBoatCopy = secondBoatCopy + 3;
                    continue;
                }
                if (i % 2 == 1)
                {

                    firstBoatTiles += command.Length;
                }
                else
                {
                    secondBoatTiles += command.Length;
                }
                if (firstBoatTiles >= 50 || secondBoatTiles >= 50)
                {
                    break;
                }
            }
            if (firstBoatTiles > secondBoatTiles)
            {
                Console.WriteLine((char)firstBoatCopy);
            }
            else
            {
                Console.WriteLine((char)secondBoatCopy);
            }
        }
    }

}