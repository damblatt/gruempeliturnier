namespace gruempeliturnier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // variables
            int amountOfTeams = 0;

            Console.WriteLine("Hello, this program will help you managing your Gruempeliturnier.");
            Console.WriteLine("First of all, tell us how many teams are going to participate?");
            while (amountOfTeams == 0 || amountOfTeams <= 0)
            {
                Console.Write("Enter a positive number: ");
                amountOfTeams = Convert.ToInt32(Console.ReadLine());
                if (amountOfTeams > 0) { Console.WriteLine($"\n{amountOfTeams} Teams are going to participate."); }
                else { Console.WriteLine($"There can't be {amountOfTeams} teams"); }
            }
        }
    }
}