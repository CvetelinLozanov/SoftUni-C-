using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            Name = name;
            Players = new List<Player>();
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }

        public List<Player> Players
        {
            get { return players; }
            set { players = value; }
        }

        public void Add(Player player)
        {
            
                Players.Add(player);
                  
        }

        public void Remove(string player)
        {
            if (!Players.Any(x => x.Name == player))
            {
                throw new ArgumentException($"Player {player} is not in {this.Name} team.");
            }
            Player pl = this.Players.FirstOrDefault(p => p.Name == player);

            this.players.Remove(pl);
        }

        public override string ToString()
        {
            return $"{Name} - {Players.Sum(x => x.AverageStats)}";
        }
    }
}
