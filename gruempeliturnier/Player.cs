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
    public class Player
    {
        // Fields
        public int amountOfPlayers = Program.amountOfPlayers; // check later, if this is really necessary. if not, go to program and remove the public static int

        // Constructor
        public Player(string playerName, string playerFirstName, int playerBirthDate, string playerGender)
        {
            this.PlayerName = playerName;
            this.PlayerFirstName = playerFirstName;
            this.PlayerBirthDate = playerBirthDate;
            this.PlayerGender = playerGender;
        }

        // Properties
        public string PlayerName { get; set; }
        public string PlayerFirstName { get; set; }
        public int PlayerBirthDate { get; set; }
        public string PlayerGender { get; set; }

        // Methods
        public void PlayerInfo()
        {
            Console.WriteLine($"\n\tName: {this.PlayerName} {this.PlayerFirstName}");
            Console.WriteLine($"\n\tBirthdate: {this.PlayerBirthDate}");
            Console.WriteLine($"\tGender: {this.PlayerGender}\n\n");
        }
    }
}
