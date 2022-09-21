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

            Console.WriteLine("Hello, this program will help you managing your Gruempeliturnier.");
            Console.WriteLine("First of all, tell us how many teams are going to participate?");

            while (!Int32.TryParse(teamInput = Console.ReadLine(), out amountOfTeams) || amountOfTeams <= 0) // prevents wrong input, only accepts integer
            {
                if (amountOfTeams <= 0 || Int32.TryParse(teamInput, out amountOfTeams) == false) { Console.Write($"\'{teamInput}\' is not a valid amount of teams. "); }
                Console.WriteLine("Enter a positive number: ");
            }
            Console.Clear();
            Console.WriteLine($"You just created {amountOfTeams} teams. You're now supposed to give every team a name.");

            List<Team> teams = new ();
            var addMoreTeams = true;
            while(addMoreTeams)
            {
                Console.Write("Enter teamname of the " + (i+1) + ". Team: ");
                teamName = Console.ReadLine();
                Console.Write("Enter amount of players of the " + (i + 1) + ". Team: ");
                //amountOfPlayers = Console.ReadLine();
                var team = new Team(teamName, 5);
                teams.Add(team);

                // ask to add more teams if true => nothing else => addMoreTeyams = fasle;
            }
        }
    }
}