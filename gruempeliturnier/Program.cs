namespace gruempeliturnier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // variables
            int amountOfTeams = 0;
            string teamInput;

            Console.WriteLine("Hello, this program will help you managing your Gruempeliturnier.");
            Console.WriteLine("First of all, tell us how many teams are going to participate?");

            while (!Int32.TryParse(teamInput = Console.ReadLine(), out amountOfTeams) || amountOfTeams <= 0) // prevents wrong input, only accepts integer
            {
                if (amountOfTeams <= 0 || Int32.TryParse(teamInput, out amountOfTeams) == false) { Console.Write($"\'{teamInput}\' is not a valid amount of teams. "); }
                Console.WriteLine("Enter a positive number: ");
            }
            Console.Clear();
            Console.WriteLine($"You just created {amountOfTeams} teams. You're now supposed to give every team a name.");
        }
    }
}