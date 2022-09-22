using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace gruempeliturnier
{
    internal class Program
    {
        internal static int amountOfTeams = 0;
        internal static List<Team> teams = new();

        static void Main(string[] args)
        {
            // variables
            string teamInput;
            string teamName;
            int amountOfPlayers;
            int teamCount = 0;
            string answer = "";
            int amountOfTeams = Program.amountOfTeams;

            Console.WriteLine("Hello, this program will help you managing your Gruempeliturnier.");
            Console.WriteLine("First of all, tell us how many teams are going to participate?");

            while (!Int32.TryParse(teamInput = Console.ReadLine(), out amountOfTeams) || amountOfTeams <= 0) // prevents wrong input, only accepts integer
            {
                if (amountOfTeams <= 0 || Int32.TryParse(teamInput, out amountOfTeams) == false) { Console.Write($"\'{teamInput}\' is not a valid amount of teams. "); }
                Console.WriteLine("Enter a positive number: ");
            }
            Console.Clear();
            Console.WriteLine($"You just created {amountOfTeams} teams. You're now supposed to give every team a name.");

            var addMoreTeams = true;
            while(addMoreTeams && teamCount < amountOfTeams)
            {
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

                if (teamCount == amountOfTeams)
                {
                    while (answer != "yes" && answer != "y" && answer != "no" && answer != "n")
                    {
                        Console.Write("Would you want to add another team? [y/n] ");
                        answer = Console.ReadLine();
                    }
                    switch (answer)
                    {
                        case "y": amountOfTeams++; answer = ""; break; // create Object, add it to list
                        case "yes": amountOfTeams++; answer = ""; break; // create Object, add it to list
                        case "n": addMoreTeams = false; answer = ""; break;
                        case "no": addMoreTeams = false; answer = ""; break;
                    }
                }
            }
            Console.Clear();
            Console.WriteLine("Here are the teams you've created:");
            Console.WriteLine("----------------------------------");
            Program.GetTeamInfo(teams);

            Console.WriteLine("Select a team by their number to add players:");
            int teamSelection = Convert.ToInt32(Console.ReadLine());
            

        }

        public static void GetTeamInfo(List<Team> teams)
        {
            int i = 1;
            foreach(var team in Program.teams)
            {
                if (team.AmountOfPlayers == 1) { Console.WriteLine($"[{i}]\t{team.TeamName}\t=> 1 slot"); }
                else { Console.WriteLine($"[{i}]\t{team.TeamName}\t=> {team.AmountOfPlayers} slots"); }
                i++;
            }
        }
    }
}