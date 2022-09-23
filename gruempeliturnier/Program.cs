using System.Data;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace gruempeliturnier
{
    internal class Program
    {
        // ConsoleHelper
        public static ConsoleHelper helper = new ConsoleHelper();
        
        public static List<Team> teams = new();
        public static int amountOfPlayers = 0;

        public static void Main(string[] args)
        {
            // welcome
            MainMenu.WelcomeMessage();
            
            // create teams: name and amount of players
            var amountOfTeams = helper.ReadInt(2);

            Console.Clear();

            Team.TeamIntroduction(amountOfTeams);

            Team.CreateTeam(amountOfTeams, teams);
            
            // create players: 
            int teamSelection = Convert.ToInt32(Team.EnterTeamMenu()) - 1; // subtract 1 to get index of the selected team

            teams[teamSelection].SetUpPlayer(teamSelection);
        }
    }
}
