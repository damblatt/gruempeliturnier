using gruempeliturnier;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("gruempeliturnier.test")]

namespace gruempeliturnier
{
    public class Team
    {
        private static ConsoleHelper helper = new ConsoleHelper();

        // Fields
        private int slotsOccupied;
        private List<Player> _players = new();

        // Constructor
        public Team(string teamName, int amountOfPlayers, int occupiedSlots)
        {
            this.TeamName = teamName;
            this.AmountOfPlayers = amountOfPlayers;
            this.OccupiedSlots = occupiedSlots;
        }

        // Properties
        public string TeamName { get; set; }
        public int AmountOfPlayers { get; set; }
        public int OccupiedSlots { get; set; }
        public int PlayerCount => _players.Count;

        public static List<Team> teams => Program.teams;

        // Methods
        public static void TeamIntroduction(int amountOfTeams)
        {
            Console.WriteLine($"You just created {amountOfTeams} teams. You're now supposed to give every team a name.");
        }

        public static void CreateTeam(int amountOfTeams, List<Team> teams)
        {
            int teamCount = 0;
            while (teamCount < amountOfTeams)
            {
                teamCount++;

                // step one, teamname and amount of players for every team
                string teamName = GetTeamName(teamCount);
                int amountOfPlayers = GetAmountOfPlayers(teamCount);

                Team team = new Team(teamName, amountOfPlayers, 0);
                teams.Add(team);
                Console.WriteLine(teams[teamCount - 1].GetTeamInfo());

                // step two, another team?
                if (teamCount == amountOfTeams)
                {
                    amountOfTeams += AddAnotherTeam();
                }
            }
        }

        private static string GetTeamName(int teamCount) // return wert nur vorübergehend gespeichert, static so in ordnung?
        {
            Console.Write("Enter teamname of the " + (teamCount) + ". Team: ");
            string teamName = Console.ReadLine();
            return teamName;
        }

        private static int GetAmountOfPlayers(int teamCount)
        {
            Console.Write("Enter amount of players of the " + (teamCount) + ". Team: ");
            int amountOfPlayers = helper.ReadInt(1);
            return amountOfPlayers;
        }

        internal string GetTeamInfo()
        {
            return $"\n\tTeamname: {this.TeamName}\n" +
                    $"\tAmount of players: {this.AmountOfPlayers}\n\n";
        }

        private static int AddAnotherTeam()
        {
            string answer;

            do
            {
                Console.Write("Would you want to add another team? [y/n] ");
                answer = Console.ReadLine();
            } while (answer != "yes" && answer != "y" && answer != "no" && answer != "n" && answer != "");

            switch (answer)
            {
                case "y": answer = ""; Console.WriteLine("\n"); 
                    return 1; 
                    break;
                case "yes": answer = ""; Console.WriteLine("\n"); 
                    return 1; 
                    break;
                case "n": answer = ""; 
                    break;
                case "no": answer = ""; 
                    break;
                case "": answer = ""; 
                    break; // shortcut for the programming process (saves time)
            }
            return 0;
        }
        
        public static int EnterTeamMenu()
        {
            string teamSelection = "";
            int n;

            // print out every team and how many slots they contain.
            GetAllTeamsInfo(teams);

            // Console.WriteLine(teams.Count); // prints out number of teams

            // the user will choose a team he wants to edit
            Console.Write("Enter the number of the team you want to edit: ");
            while (!Int32.TryParse(teamSelection = Console.ReadLine(), out n) || n <= 0 || n > teams.Count) // only int, only positive numbers, only numbers related to a team
            {
                Console.Write("Enter the number of the team you want to edit: ");
            }
            PrintTeamName(n - 1);
            return n;
        }

        public static void GetAllTeamsInfo(List<Team> teams)
        {
            int i = 1;

            Console.Clear();
            Console.WriteLine("Gruempeliturnier teams:");
            Console.WriteLine("----------------------------------");
            foreach (var team in teams)
            {
                if (team.AmountOfPlayers == 1 && team.OccupiedSlots == 0) { Console.WriteLine($"[{i}]\t{team.TeamName}\t\t=> {team.AmountOfPlayers} player slot, {team.OccupiedSlots} slots occupied"); }
                else if (team.AmountOfPlayers == 1 && team.OccupiedSlots == 1) { Console.WriteLine($"[{i}]\t{team.TeamName}\t\t=> {team.AmountOfPlayers} player slot, {team.OccupiedSlots} slot occupied"); }
                else if (team.OccupiedSlots == 1) { Console.WriteLine($"[{i}]\t{team.TeamName}\t\t=> {team.AmountOfPlayers} player slots, {team.OccupiedSlots} slot occupied"); }
                else { Console.WriteLine($"[{i}]\t{team.TeamName}\t\t=> {team.AmountOfPlayers} player slots, {team.OccupiedSlots} slots occupied"); }
                i++;
            }
        }

        private static void PrintTeamName(int currentTeam)
        {
            Console.WriteLine($"Team: {teams[currentTeam].TeamName}");
        }


        public void SetUpPlayer(int teamSelection)
        {
            Player.CreatePlayer(teams[teamSelection].AmountOfPlayers, _players);
            // Player.GetPlayerData(teams[teamSelection].PlayerCount);
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
