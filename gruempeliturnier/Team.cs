using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("gruempeliturnier.test")]

namespace gruempeliturnier
{
    internal class Team
    {
        // Fields
        public int amountOfTeams = Program.amountOfTeams;
        public int amountOfPlayers;

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
        public void TeamInfo()
        {
            Console.WriteLine($"\n\tTeamname: {this.TeamName}\n" +
                $"\tAmount of players: {this.AmountOfPlayers}\n\n");
        }
    }
}
