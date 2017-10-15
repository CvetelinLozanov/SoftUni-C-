using System;
using System.Linq;
using System.Collections.Generic;

namespace _05.Hands_of_Cards
{
    class Program
    {
        static void Main()
        {
            var namesCards = new Dictionary<string, List<int>>();
            var line = Console.ReadLine();
            while (line != "JOKER")
            {
                var tokens = line.Split(':');
                var name = tokens[0];
                var cards = tokens[1].Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .Select(CalculateCarValue).ToArray();
                if (!namesCards.ContainsKey(name))
                {
                    namesCards[name] = new List<int>();
                }
                namesCards[name].AddRange(cards);
                line = Console.ReadLine();
            }
            foreach (var nameCards in namesCards)
            {
                var name = nameCards.Key;
                var cards = nameCards.Value;

                var totalCardsSum = cards.Distinct().Sum();
                Console.WriteLine($"{name}: {totalCardsSum}");
            }

        }

        private static int CalculateCarValue(string card)
        {
            var cardPowers = new Dictionary<string, int>();
            cardPowers["J"] = 11;
            cardPowers["Q"] = 12;
            cardPowers["K"] = 13;
            cardPowers["A"] = 14;
            for (int i = 2; i <= 10; i++)
            {
                cardPowers[i.ToString()] = i;
            }
            var cardTypes = new Dictionary<string, int>();
            cardTypes["S"] = 4;
            cardTypes["H"] = 3;
            cardTypes["D"] = 2;
            cardTypes["C"] = 1;
            var power = card.Substring(0, card.Length - 1);
            var type = card.Substring(card.Length - 1);

            var value = cardPowers[power] * cardTypes[type];
            return value;
        }
    }
}