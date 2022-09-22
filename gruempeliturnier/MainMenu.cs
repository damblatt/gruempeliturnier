using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gruempeliturnier
{
    internal class MainMenu
    {
        public static ConsoleHelper helper = new ConsoleHelper();

        public static void WelcomeMessage()
        {
            Console.WriteLine("Hello, this program will help you managing your Gruempeliturnier.");
            Console.Write("How many teams would you like to create? Enter a positive number: ");
        }
    }
}
