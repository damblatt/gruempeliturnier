using System.Data;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace gruempeliturnier
{
    internal class Program
    {
        public static ConsoleHelper helper = new ConsoleHelper();
        
        public static int amountOfTeams = 0;
        public static int amountOfPlayers = 0;
        public static List<Team> teams = new();


        static void Main(string[] args)
        {
            // variables
            string teamInput;
            int amountOfTeams = Program.amountOfTeams;
            int teamCount = 0;
            string teamName;
            int amountOfPlayers = Program.amountOfPlayers;
            string answer = "";
            int menuSelection;

            // welcome message
            MainMenu.WelcomeMessage();
            
            // amount of teams
            amountOfTeams = helper.ReadInt(2);

            Console.Clear();
            Team.TeamIntroduction();

            Team.Set
            
            menuSelection = Convert.ToInt32(TeamMenu()); // opens team menu, which gets the team info and asks the user for input. the selected team is given to the int menuSelection
            Console.WriteLine(teams[menuSelection - 1].TeamName); //
            //PlayerMenu(teams[menuSelection - 1].TeamName, menuSelection);
        }

        public static string TeamMenu()
        {
            string teamSelection = "";
            int n;

            Console.Clear();
            Console.WriteLine("Gruempeliturnier teams:");
            Console.WriteLine("----------------------------------");

            // print out every team and how many slots they contain.
            Program.TeamInfo(teams);

            // Console.WriteLine(teams.Count); // prints out number of teams

            // the user will choose a team he wants to edit
            Console.Write("Enter the number of the team you want to edit: ");
            while (!Int32.TryParse(teamSelection = Console.ReadLine(), out n) || n <= 0 || n > teams.Count) // only int, only positive numbers, only numbers related to a team
            {
                Console.Write("Enter the number of the team you want to edit: ");
            }
            return teamSelection;
        }

        public static void TeamInfo(List<Team> teams)
        {
            int i = 1;
            foreach(var team in Program.teams)
            {
                if (team.AmountOfPlayers == 1) { Console.WriteLine($"[{i}]\t{team.TeamName}\t=> 1 available slot, "); }
                else { Console.WriteLine($"[{i}]\t{team.TeamName}\t=> {team.AmountOfPlayers} available slots"); }
                i++;
            }
        }

        public static void TeamName(int currentTeam)
        {
            Console.WriteLine(teams[currentTeam].TeamName);
        }

        public static string PlayerMenu(string teamName, int teamNumber)
        {
            Console.Write("test");
            Console.Clear();
            Console.WriteLine($"You're currently editing team {teamName} [{teamNumber}].");
            string teamSelection = "";
            int n;

            Console.Clear();
            Console.WriteLine("Gruempeliturnier teams:");
            Console.WriteLine("----------------------------------");

            // print out every team and how many slots they contain.
            Program.TeamInfo(teams);

            // Console.WriteLine(teams.Count); // prints out number of teams

            // the user will choose a team he wants to edit
            Console.WriteLine("Select a team by their number to add players:");
            while (!Int32.TryParse(teamSelection = Console.ReadLine(), out n) || n <= 0 || n > teams.Count) // only int, only positive numbers, only numbers related to a team
            {
                Console.WriteLine("Select a team by their number to add players:");
            }
            return teamSelection;
        }
    }
}
