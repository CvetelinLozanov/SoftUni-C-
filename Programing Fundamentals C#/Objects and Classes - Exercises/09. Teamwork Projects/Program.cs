using System;
using System.Linq;
using System.Collections.Generic;

namespace _09.Teamwork_Projects
{
    class Program
    {
        static void Main()
        {
            int lines = int.Parse(Console.ReadLine());
            List<Team> teams = ReadTeams(lines);
            string input = Console.ReadLine();
            while (input != "end of assignment")
            {
                var userWithTeam = input.Split(new char[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = userWithTeam[0];
                string teamToJoin = userWithTeam[1];
                if (!teams.Any(t => t.Name == teamToJoin))
                {
                    Console.WriteLine($"Team {teamToJoin} does not exist!");
                }
                else if (teams.Select(x => x.Members).Any(t => t.Contains(name)) || teams.Any(t => t.CreatorName == name))
                {
                    Console.WriteLine($"Member {name} cannot join team {teamToJoin}!");
                }
                else
                {
                    int indexForInsert = teams.FindIndex(x => x.Name == teamToJoin);
                    teams[indexForInsert].Members.Add(name);
                }
                input = Console.ReadLine();
            }
            var teamsToDisbond = teams.OrderBy(n => n.Name).Where(t => t.Members.Count == 0);
            var fullTeams = teams.OrderByDescending(n => n.Members.Count).ThenBy(n => n.Name).Where(t => t.Members.Count > 0);

            foreach (var team in fullTeams)
            {
                Console.WriteLine(team.Name);
                Console.WriteLine($"- {team.CreatorName}");
                foreach (var person in team.Members.OrderBy(p => p))
                {
                    Console.WriteLine($"-- {person}");
                }
            }
            Console.WriteLine("Teams to disband:");
            foreach (var team in teamsToDisbond)
            {
                Console.WriteLine(team.Name);
            }
        }

        private static List<Team> ReadTeams(int lines)
        {
            List<Team> teams = new List<Team>();
            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                string teamName = input[1];
                List<string> members = new List<string>();
                Team team = new Team();
                team.Name = teamName;
                team.CreatorName = name;
                team.Members = members;
                if (!teams.Select(t => t.Name).Contains(team.Name))
                {
                    if (!teams.Select(t => t.CreatorName).Contains(team.CreatorName))
                    {
                        teams.Add(team);
                        Console.WriteLine($"Team {team.Name} has been created by {team.CreatorName}!");
                    }
                    else
                    {
                        Console.WriteLine($"{team.CreatorName} cannot create another team!");
                    }
                }
                else
                {
                    Console.WriteLine($"Team {team.Name} was already created!");
                }               
            }
            return teams;
        }
    }
    class Team
    {
        public string Name { get; set; }
        public List<string> Members { get; set; }
        public string CreatorName { get; set; }
    }
}