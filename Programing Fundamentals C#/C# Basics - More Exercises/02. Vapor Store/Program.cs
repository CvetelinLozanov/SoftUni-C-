using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            var money = double.Parse(Console.ReadLine());
            string game = Console.ReadLine();
            var gamePrice = 0.0;
            var moneyCopy = money;

            while (game != "Game Time")
            {

                if (game == "OutFall 4")
                {
                    gamePrice = 39.99;
                }
                else if (game == "CS: OG")
                {
                    gamePrice = 15.99;
                }
                else if (game == "Zplinter Zell")
                {
                    gamePrice = 19.99;
                }
                else if (game == "Honored 2")
                {
                    gamePrice = 59.99;
                }
                else if (game == "RoverWatch")
                {
                    gamePrice = 29.99;
                }
                else if (game == "RoverWatch Origins Edition")
                {
                    gamePrice = 39.99;
                }
                else
                {
                    Console.WriteLine("Not Found");
                    game = Console.ReadLine();
                    continue;
                }
                if (gamePrice > money)
                {
                    Console.WriteLine("Too Expensive");
                }
                else
                {
                    money -= gamePrice;
                    Console.WriteLine($"Bought {game}");
                }

                if (money == 0)
                {
                    Console.WriteLine("Out of money!");
                    return;
                }
                game = Console.ReadLine();
            }
            Console.WriteLine($"Total spent: ${(moneyCopy - money):F2}. Remaining: ${money:F2}");
        }
    }
}