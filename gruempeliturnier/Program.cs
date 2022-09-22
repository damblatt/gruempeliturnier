using System.Numerics;

namespace gruempeliturnier
{
    internal class Program
    {
        internal static int amountOfTeams = 0;

        static void Main(string[] args)
        {
            // variables
            string teamInput;
            string teamName;
            int amountOfPlayers;
            int teamCount;
            int i = 0;
            string answer = "";

            Console.WriteLine("Hello, this program will help you managing your Gruempeliturnier.");
            Console.WriteLine("First of all, tell us how many teams are going to participate?");

            while (!Int32.TryParse(teamInput = Console.ReadLine(), out amountOfTeams) || amountOfTeams <= 0) // prevents wrong input, only accepts integer
            {
                if (amountOfTeams <= 0 || Int32.TryParse(teamInput, out amountOfTeams) == false) { Console.Write($"\'{teamInput}\' is not a valid amount of teams. "); }
                Console.WriteLine("Enter a positive number: ");
            }
            Console.Clear();
            Console.WriteLine($"You just created {amountOfTeams} teams. You're now supposed to give every team a name.");
            teamCount = Program.amountOfTeams;

            List<Team> teams = new ();
            var addMoreTeams = true;
            while(addMoreTeams && teamCount > 0)
            {
                teamCount--;
                i++;
                Console.Write("Enter teamname of the " + (i) + ". Team: ");
                teamName = Console.ReadLine();
                do
                {
                    Console.Write("Enter amount of players of the " + (i) + ". Team: ");
                } while (Int32.TryParse(Console.ReadLine(), out amountOfPlayers) == false && amountOfPlayers <= 0);
                
                var team = new Team(teamName, amountOfPlayers);
                teams.Add(team);
                teams[i - 1].ReadInfo();

                if (i == amountOfTeams)
                {
                    while (answer != "yes" && answer != "y" && answer != "no" && answer != "n")
                    {
                        Console.Write("Would you want to add another team? [y/n] ");
                        answer = Console.ReadLine();
                    }
                    switch (answer)
                    {
                        case "y": teamCount++; i = teamCount;  break; // create Object, add it to list
                        case "yes": teamCount++; i = teamCount; break; // create Object, add it to list
                        case "n": addMoreTeams = false; break;
                        case "no": addMoreTeams = false; break;
                    }
                }
            }

        }
    }
}