using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    public class Engine
    {
        private DungeonMaster dunegonMaster;

        public Engine()
        {
            this.dunegonMaster = new DungeonMaster();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (!string.IsNullOrEmpty(input))
            {
                string[] inputArgs = input.Split();
                string command = inputArgs[0];
                string[] args = inputArgs.Skip(1).ToArray();

                string result = string.Empty;

                try
                {                   
                    switch (command)
                    {
                        case "JoinParty":
                            result = dunegonMaster.JoinParty(args);
                            break;
                        case "AddItemToPool":
                            result = dunegonMaster.AddItemToPool(args);
                            break;
                        case "PickUpItem":
                            result = dunegonMaster.PickUpItem(args);
                            break;
                        case "UseItem":
                            result = dunegonMaster.UseItem(args);
                            break;
                        case "UseItemOn":
                            result = dunegonMaster.UseItemOn(args);
                            break;
                        case "GiveCharecterItem":
                            result = dunegonMaster.GiveCharacterItem(args);
                            break;
                        case "GetStats":
                            result = dunegonMaster.GetStats();
                            break;
                        case "Attack":
                            result = dunegonMaster.Attack(args);
                            break;
                        case "Heal":
                            result = dunegonMaster.Heal(args);
                            break;
                        case "EndTurn":
                            result = dunegonMaster.EndTurn(args);
                            break;
                        case "IsGameOver":
                            dunegonMaster.IsGameOver();
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine(result);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine("Parameter Error: " + ae.Message);
                }
                catch (InvalidOperationException ie)
                {
                    Console.WriteLine("Invalid Operation: " + ie.Message);
                }              

                if (dunegonMaster.IsGameOver())
                {
                    break;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine("Final stats:");
            Console.WriteLine(dunegonMaster.GetStats());
        }
    }
}
