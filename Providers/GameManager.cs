using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TechTyccoon2;
using TechTyccoon2.Utilities;
using Figgle;

namespace TechTyccoon2.Providers
{
    public static class GameManager
    {
        public static int Year { get; set; }
        public static Version Version { get; set; } = new Version(0, 0, 1, 0);
        public static List<string> Names { get; set; }

        public static ProductsManager ProductionManager = new ProductsManager();
        public static void InitializeGame(bool newGame)
        {
            if (newGame == true)
            {
                Console.Clear();
                Utils.SendError("Please enter a quantity of companies to generate!");
                var input = int.Parse(Console.ReadLine());

                if (input > 0)
                {
                    InitializeCompanies(input);
                }
                else
                {
                    InitializeGame(true);



                }
            }
            else
            {
                var gameName = "TECH-TYCOON 2";
                var author = $"Alpha {Version} - Fully developed by RenderBr / Average";
                Utils.SendCustom($"{FiggleFonts.Standard.Render(gameName)}{author}", ConsoleColor.Yellow, true);
                Console.WriteLine("Hello and welcome to TechTycoon! This is a story-based company generator. It is a C# console app, bordering being a game, but not quite. Feel free to screw around with this ebic piece of software." +
                    "\n\n\rTo begin, type in a valid quantity, this will be the number of companies generated:");
                int input;
                bool worked = int.TryParse(Console.ReadLine(), out input);
                if (!worked)
                {
                    InitializeGame(true);
                }
                Console.Clear();
                InitializeCompanies(input);
            }

        }

        public static void InitializeCompanies(int quantity)
        {
            float percentage;
            for (float i = 0; i < quantity; i++)
            {
                percentage = (int)Math.Round((i + 1) / quantity * 100);
                var generated = Companies.GenerateRandomCompany();
                Companies.Add(generated);
                Utils.UpdateMessage(i + " Companies Generated - " + percentage + "%");
            }
            Console.WriteLine("\n\nPlease enter a command: (Use help)\n");


            HandleCommand();

        }


        public static void HandleCommand()
        {
            string input = string.Format(Console.ReadLine());
            if (input.Length == 0)
            {
                HandleCommand();
            }
            List<string> args = new List<string>();
            args = Utils.ParseParameters(input);

            CommandHandler.HandleCommand(args);
            HandleCommand();

        }



    }

}
