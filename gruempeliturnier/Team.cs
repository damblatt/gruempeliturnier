using gruempeliturnier;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("gruempeliturnier.test")]

namespace gruempeliturnier
{
    internal class Team
    {
        public static ConsoleHelper helper = new ConsoleHelper();

        // Fields
        public int slotsOccupied;
        private List<Player> _players = new();

        // Constructor
        public Team(string teamName, int amountOfPlayers)
        {
            this.TeamName = teamName;
            this.AmountOfPlayers = amountOfPlayers;
        }

        // Properties
        public string TeamName { get; set; }
        public int AmountOfPlayers { get; set; }
        public int TeamCount => _players.Count;

        public static void TeamIntroduction()
        {
            Console.WriteLine($"You just created {Program.amountOfTeams} teams. You're now supposed to give every team a name.");
        }

        public Team CreateTeam()
        {
            var addMoreTeams = true;
            while (addMoreTeams && TeamCount < amountOfTeams)
            {
                //teamCount = consoleHelper.ReadInt(1, 10);
                // step one, teamname and amount of players for every team
                teamCount++;
                string teamName = SetTeamName();
                Console.Write("Enter teamname of the " + (teamCount) + ". Team: ");
                teamName = Console.ReadLine();
                do
                {
                    Console.Write("Enter amount of players of the " + (teamCount) + ". Team: ");
                } while (Int32.TryParse(Console.ReadLine(), out amountOfPlayers) == false && amountOfPlayers <= 0);

                Team team = new Team(teamName, amountOfPlayers);
                teams.Add(team);
                Console.WriteLine(teams[teamCount - 1].TeamInfo());

                // step two, another player?
                if (teamCount == amountOfTeams)
                {
                    do
                    {
                        Console.Write("Would you want to add another team? [y/n] ");
                        answer = Console.ReadLine();
                    } while (answer != "yes" && answer != "y" && answer != "no" && answer != "n" && answer != "");

                    /*
                    while (answer != "yes" && answer != "y" && answer != "no" && answer != "n" && answer != "")
                    {
                        Console.Write("Would you want to add another team? [y/n] ");
                        answer = Console.ReadLine();
                    }
                    */
                    switch (answer)
                    {
                        case "y": amountOfTeams++; answer = ""; break;
                        case "yes": amountOfTeams++; answer = ""; break;
                        case "n": addMoreTeams = false; answer = ""; break;
                        case "no": addMoreTeams = false; answer = ""; break;
                        case "": addMoreTeams = false; answer = ""; break; // shortcut for the programming process (saves time)
                    }
                }
            }
            return default;
        }

        public string SetTeamName(string teamName)
        {
            Console.Write("Enter teamname of the " + (TeamCount) + ". Team: ");
            teamName = Console.ReadLine();
            return teamName;
        }

        public int SetAmountOfPlayers(int amountOfPlayers)
        {
            Console.Write("Enter amount of players of the " + (TeamCount) + ". Team: ");
            helper.ReadInt(1);
            return amountOfPlayers;
        }

        // Methods
        public string TeamInfo()
        {
            //Console.WriteLine($"\n\tTeamname: {this.TeamName}\n" +
            //    $"\tAmount of players: {this.AmountOfPlayers}\n\n");
            return $"\n\tTeamname: {this.TeamName}\n" +
                    $"\tAmount of players: {this.AmountOfPlayers}\n\n";
        }

        public void NewPlayer(string playerName, string playerLastName, int playerBirthDate, string playerGender)
        {
            Player player = new Player(playerName, playerLastName, playerBirthDate, playerGender);
            _players.Add(player);
        }

        public Player? GetPlayerByNameOrDefault(string name)
        {
            foreach (var player in _players)
            {
                if (string.Equals(name, player.PlayerName, StringComparison.InvariantCultureIgnoreCase))
                {
                    return player;
                }
            }
            return null;
        }

        /*
        public void Foo()
        {
            while (true)
            {
                while(true)
                {
                    if (true)
                    {
                        goto test;
                    }
                }
            }

        test:

            Console.WriteLine("Finished");
        }
        */
    }
}
/*
while(addMoreTeams && teamCount < amountOfTeams)
{
    // step one, teamname and amount of players for every team
    teamCount++;
    Console.Write("Enter teamname of the " + (teamCount) + ". Team: ");
    teamName = Console.ReadLine();
    do
    {
        Console.Write("Enter amount of players of the " + (teamCount) + ". Team: ");
    } while (Int32.TryParse(Console.ReadLine(), out amountOfPlayers) == false && amountOfPlayers <= 0);

    Team team = new Team(teamName, amountOfPlayers);
    teams.Add(team);
    teams[teamCount - 1].TeamInfo();

    // step two, another player?
    if (teamCount == amountOfTeams)
    {
        while (answer != "yes" && answer != "y" && answer != "no" && answer != "n")
        {
            Console.Write("Would you want to add another team? [y/n] ");
            answer = Console.ReadLine();
        }
        switch (answer)
        {
            case "y": amountOfTeams++; answer = ""; break;
            case "yes": amountOfTeams++; answer = ""; break;
            case "n": addMoreTeams = false; answer = ""; break;
            case "no": addMoreTeams = false; answer = ""; break;
        }
    }
}
*/
