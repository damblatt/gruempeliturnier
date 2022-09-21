using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gruempeliturnier
{
    internal class Team
    {
        public int amountOfTeams = Program.amountOfTeams;
        public string teamName;
        public int amountOfPlayers;

        public Team(string teamName, int amountOfPlayers)
        {
            this.TeamName = teamName;
            this.AmountOfPlayers = amountOfPlayers;
        }

        public string TeamName { get; set; }
        public int AmountOfPlayers { get; set; }
    }
}
