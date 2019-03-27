using DungeonsAndCodeWizards.Models.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Factories
{
    public class CharacterFactory
    {
        public Character CreateCharacter(string faction, string characterType,string name)
        {
            characterType = characterType.ToLower();

            Character character;

            if (!Enum.TryParse(faction, out Faction factionResult))
            {
                throw new ArgumentException($"Invalid faction \"{faction}\"!");
            }

            switch (characterType)
            {
                case "warrior":
                    character = new Warrior(name, factionResult);
                    break;
                case "cleric":
                    character = new Cleric(name, factionResult);
                    break;
                default:
                    throw new ArgumentException($"Invalid character type \"{characterType}\"!");
            }

            return character;
        }
    }
}
