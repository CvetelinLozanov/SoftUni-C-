using System;
using System.Linq;
using System.Collections.Generic;

namespace _11.Dragon_Army
{

    class Program
    {
        class DragonStat
        {
            public string Type { get; set; }
            public string Name { get; set; }
            public string Damage { get; set; }
            public string Health { get; set; }
            public string Armor { get; set; }
        }
        static void Main()
        {
            var dragons = new Dictionary<string, SortedDictionary<string, int[]>>();
            int lines = int.Parse(Console.ReadLine());
            var dragonsInfo = ReadDragons(lines);
            foreach (var dragon in dragonsInfo)
            {
                var type = dragon.Type;
                var name = dragon.Name;
                int damage = 0;
                int health = 0;
                int armor = 0;
                damage = dragon.Damage == "null" ? 45 : int.Parse(dragon.Damage);
                health = dragon.Health == "null" ? 250 : int.Parse(dragon.Health);
                armor = dragon.Armor == "null" ? 10 : int.Parse(dragon.Armor);
                if (!dragons.ContainsKey(type))
                {
                    dragons.Add(type, new SortedDictionary<string, int[]>());
                }
                if (!dragons[type].ContainsKey(name))
                {
                    dragons[type].Add(name, new int[3]);
                }
                dragons[type][name][0] = damage;
                dragons[type][name][1] = health;
                dragons[type][name][2] = armor;
            }
            foreach (var outPair in dragons)
            {
                Console.WriteLine("{0}::({1:f2}/{2:f2}/{3:f2})",
                    outPair.Key,
                    outPair.Value.Select(a => a.Value[0]).Average(),
                    outPair.Value.Select(a => a.Value[1]).Average(),
                    outPair.Value.Select(a => a.Value[2]).Average());
                foreach (var dragon in outPair.Value)
                {

                    var damage = dragon.Value[0];
                    var health = dragon.Value[1];
                    var armor = dragon.Value[2];
                    Console.WriteLine("-{0} -> damage: {1}, health: {2}, armor: {3}", dragon.Key, damage, health, armor);
                }
            }
        }

        private static List<DragonStat> ReadDragons(int lines)
        {
            var listOfDragons = new List<DragonStat>();
            for (int i = 0; i < lines; i++)
            {
                var dragonsInfo = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var type = dragonsInfo[0];
                var name = dragonsInfo[1];
                var damage = dragonsInfo[2];
                var health = dragonsInfo[3];
                var armor = dragonsInfo[4];
                DragonStat dragon = new DragonStat()
                {
                    Type = type,
                    Name = name,
                    Damage = damage,
                    Health = health,
                    Armor = armor
                };
                listOfDragons.Add(dragon);
            }
            return listOfDragons;
        }
    }
}
