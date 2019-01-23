using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        public static List<Team> teams;
        public static void Main(string[] args)
        {
            teams = new List<Team>();
            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] commandArgs = command
                    .Split(';');
                if (commandArgs.Length == 2)
                {
                    string commandName = commandArgs[0];
                    switch (commandName)
                    {
                        case "Team":
                            string teamName = commandArgs[1];
                            try
                            {
                                Team team = new Team(teamName);
                                teams.Add(team);
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine(ex.Message);
                                command = Console.ReadLine();
                                continue;
                            }
                            break;
                        case "Rating":
                            string teamNameForPrint = commandArgs[1];
                            Team teamForPrint = GetTeam(teamNameForPrint);
                            Console.WriteLine(teamForPrint.ToString());
                            break;
                        default:
                            break;
                    }
                }
                else if (commandArgs.Length == 8)
                {

                    string teamName = commandArgs[1];
                    string playerName = commandArgs[2];
                    int endurance = int.Parse(commandArgs[3]);
                    int sprint = int.Parse(commandArgs[4]);
                    int dribble = int.Parse(commandArgs[5]);
                    int passing = int.Parse(commandArgs[6]);
                    int shooting = int.Parse(commandArgs[7]);
                    try
                    {
                        Player player = new Player(playerName,
                       endurance,
                       sprint,
                       dribble,
                       passing,
                       shooting);
                        if (!teams.Any(x => x.Name == teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            command = Console.ReadLine();
                            continue;
                        }
                        teams.FirstOrDefault(t => t.Name == teamName).Add(player);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                        command = Console.ReadLine();
                        continue;
                    }
                }
                else if (commandArgs.Length == 3)
                {
                    string teamName = commandArgs[1];
                    string playerForRemove = commandArgs[2];                 
                    try
                    {
                        teams.FirstOrDefault(x => x.Name == teamName).Remove(playerForRemove);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                        command = Console.ReadLine();
                        continue;
                    }
                    
                }
                command = Console.ReadLine();
            }
           
        }

        private static Team GetTeam(string teamNameForPrint)
        {
            return teams.FirstOrDefault(x => x.Name == teamNameForPrint);
        }        
    }
}
