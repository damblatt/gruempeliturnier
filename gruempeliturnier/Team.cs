using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gruempeliturnier
{
    internal class Team
    {
        // Variables
        public int amountOfTeams = Program.amountOfTeams;

        // Constructor
        public Team(string teamName, int amountOfPlayers)
        {
            this.TeamName = teamName;
            this.AmountOfPlayers = amountOfPlayers;
        }

        // Properties
        public string TeamName { get; set; }
        public int AmountOfPlayers { get; set; }

        // Methods
        public void ReadInfo()
        {
            Console.WriteLine($"Teamname: {this.TeamName}");
            Console.WriteLine($"{this.AmountOfPlayers}\n");
        }
    }
}
