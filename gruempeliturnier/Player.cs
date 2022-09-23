using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("gruempeliturnier.test")]

namespace gruempeliturnier
{
    public class Player
    {
        private static ConsoleHelper helper = new ConsoleHelper();

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

        /*
        public static void GetPlayerData(int playerCount)
        {
            string playerName = SetPlayerName(playerCount);
            string playerFirstName = SetPlayerFirstName(playerCount);
            int playerBirthDate = SetPlayerBirthDate(playerCount);
            string playerGender = SetPlayerGender(playerCount);
        }
        */

        public static void CreatePlayer(int teamSelection, int amountOfPlayers, List<Player> players)
        {
            int playerCount = 0;
            int occupiedSlots = 0;
            while (playerCount < amountOfPlayers)
            {
                playerCount++;
                occupiedSlots++;

                // step one, player's name, firstname, birth date and gender for every player
                string playerName = SetPlayerName(playerCount);
                string playerFirstName = SetPlayerFirstName(playerCount);
                int playerBirthDate = SetPlayerBirthDate(playerCount);
                string playerGender = SetPlayerGender(playerCount);

                Player player = new Player(playerName, playerFirstName, playerBirthDate, playerGender);
                players.Add(player);
                Console.WriteLine(players[playerCount - 1].GetPlayerInfo());
            }
            if (occupiedSlots == amountOfPlayers)
            {
                amountOfPlayers += AddAnotherPlayer();
            }
            Team.teams[teamSelection].OccupiedSlots = occupiedSlots;
            teamSelection = Convert.ToInt32(Team.EnterTeamMenu()) - 1;
            Team.teams[teamSelection].SetUpPlayer(teamSelection);
        }

        private static string SetPlayerName(int playerCount)
        {
            Console.Write("Enter name of the " + (playerCount) + ". player: ");
            string playerName = Console.ReadLine();
            return playerName;
        }

        private static string SetPlayerFirstName(int playerCount)
        {
            Console.Write("Enter first name of the " + (playerCount) + ". player: ");
            string playerName = Console.ReadLine();
            return playerName;
        }

        private static int SetPlayerBirthDate(int playerCount)
        {
            Console.Write("Enter birth date of the " + (playerCount) + ". player: ");
            int birthDate = helper.ReadInt(1);
            return birthDate;
        }

        private static string SetPlayerGender(int playerCount)
        {
            Console.Write("Enter gender of the " + (playerCount) + ". player: ");
            string playerGender = Console.ReadLine();
            return playerGender;
        }

        private static int AddAnotherPlayer()
        {
            string answer;

            do
            {
                Console.Write("Would you want to add another player? [y/n] ");
                answer = Console.ReadLine();
            } while (answer != "yes" && answer != "y" && answer != "no" && answer != "n" && answer != "");

            switch (answer)
            {
                case "y":
                    answer = ""; Console.WriteLine("\n");
                    return 1;
                    break;
                case "yes":
                    answer = ""; Console.WriteLine("\n");
                    return 1;
                    break;
                case "n":
                    answer = "";
                    break;
                case "no":
                    answer = "";
                    break;
                case "":
                    answer = "";
                    break; // shortcut for the programming process (saves time)
            }
            return 0;
        }

        private string GetPlayerInfo()
        {
            return $"\n\tName: {this.PlayerName} {this.PlayerFirstName}\n" +
                    $"\tBirth date: {this.PlayerBirthDate}\n" +
                    $"\tGender: {this.PlayerGender}\n\n";
        }

        // Methods
        /*
        public static string PlayerMenu(string teamName, int teamNumber)
        {
            Console.Write("test");
            // Console.Clear();
            Console.WriteLine($"You're currently editing team {teamName} [{teamNumber}].");
            return default;
        }

        public void PlayerInfo()
        {
            Console.WriteLine($"\n\tName: {this.PlayerName} {this.PlayerFirstName}");
            Console.WriteLine($"\n\tBirthdate: {this.PlayerBirthDate}");
            Console.WriteLine($"\tGender: {this.PlayerGender}\n\n");
        }
        */
    }
}
