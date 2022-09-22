using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace gruempeliturnier
{
    internal class Program
    {
        public static int amountOfTeams = 0; // public --> internal bei error
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
            Console.WriteLine("Hello, this program will help you managing your Gruempeliturnier.");
            Console.WriteLine("First of all, tell us how many teams are going to participate?");

            // ask for the amount of teams
            while (!Int32.TryParse(teamInput = Console.ReadLine(), out amountOfTeams) || amountOfTeams <= 0) // prevents wrong input, only accepts integer
            {
                if (amountOfTeams <= 0 || Int32.TryParse(teamInput, out amountOfTeams) == false) { Console.Write($"\'{teamInput}\' is not a valid amount of teams. "); }
                Console.WriteLine("Enter a positive number: ");
            }
            Console.Clear();
            Console.WriteLine($"You just created {amountOfTeams} teams. You're now supposed to give every team a name.");

            // step one: choose name and number of players for every team.
            // step two: ask for another players.
            // if answer == yes, repeat step 1 and two
            var addMoreTeams = true;
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

            menuSelection = Convert.ToInt32(TeamMenu());

        }

        public static string TeamMenu()
        {
            string teamSelection = "";
            int n;

            Console.Clear();
            Console.WriteLine("Gruempeliturnier teams:");
            Console.WriteLine("----------------------------------");

            // print out every team and how many slots they contain.
            Program.GetTeamInfo(teams);

            // Console.WriteLine(teams.Count); // prints out number of teams

            // the user will choose a team he wants to edit
            Console.WriteLine("Select a team by their number to add players:");
            while (!Int32.TryParse(teamSelection = Console.ReadLine(), out n) || n <= 0 || n > teams.Count) // only int, only positive numbers, only numbers related to a team
            {
                Console.WriteLine("Select a team by their number to add players:");
            }
            return teamSelection;
        }

        public static void GetTeamInfo(List<Team> teams)
        {
            int i = 1;
            foreach(var team in Program.teams)
            {
                if (team.AmountOfPlayers == 1) { Console.WriteLine($"[{i}]\t{team.TeamName}\t=> 1 available slot, "); }
                else { Console.WriteLine($"[{i}]\t{team.TeamName}\t=> {team.AmountOfPlayers} available slots"); }
                i++;
            }
        }
    }
}
