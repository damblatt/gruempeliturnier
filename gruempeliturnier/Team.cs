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
        public int PlayersCount => _players.Count;

        public static void TeamIntroduction(int amountOfTeams)
        {
            Console.WriteLine($"You just created {amountOfTeams} teams. You're now supposed to give every team a name.");
        }

        public static Team CreateTeam(int amountOfTeams, int teamCount, List<Team> teams)
        {
            bool addMoreTeams = true;
            while (addMoreTeams && teamCount < amountOfTeams)
            {
                teamCount++;

                // step one, teamname and amount of players for every team
                string teamName = SetTeamName(teamCount);
                int amountOfPlayers = SetAmountOfPlayers(teamCount);

                Team team = new Team(teamName, amountOfPlayers);
                teams.Add(team);
                Console.WriteLine(teams[teamCount - 1].TeamInfo());

                    // Console.WriteLine(teamCount); // Check teamCount value
                    // Console.WriteLine(amountOfTeams); // check amountOfTeams value

                // step two, another team?
                if (teamCount == amountOfTeams)
                {
                    amountOfTeams += AddAnotherTeam(amountOfTeams, addMoreTeams);
                }
            }
            return default;
        }

        public static string SetTeamName(int teamCount) // return wert nur vorübergehend gespeichert, static so in ordnung?
        {
            Console.Write("Enter teamname of the " + (teamCount) + ". Team: ");
            string teamName = Console.ReadLine();
            return teamName;
        }

        public static int SetAmountOfPlayers(int teamCount)
        {
            Console.Write("Enter amount of players of the " + (teamCount) + ". Team: ");
            int amountOfPlayers = helper.ReadInt(1);
            return amountOfPlayers;
        }

        public static int AddAnotherTeam(int amountOfTeams, bool addMoreTeams)
        {
            string answer;

            do
            {
                Console.Write("Would you want to add another team? [y/n] ");
                answer = Console.ReadLine();
            } while (answer != "yes" && answer != "y" && answer != "no" && answer != "n" && answer != "");

            switch (answer)
            {
                case "y": answer = ""; return 1; break;
                case "yes": answer = ""; return 1; break;
                case "n": answer = ""; break;
                case "no": answer = ""; break;
                case "": answer = ""; break; // shortcut for the programming process (saves time)
            }
            return default;
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

    }
}
