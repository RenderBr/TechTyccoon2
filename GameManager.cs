using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TechTyccoon2.CompanyTypes;

namespace TechTyccoon2
{
    public static class GameManager
    {
        public static int Year { get; set; }

        public static void InitializeGame(bool newGame)
        {
            if(newGame == true)
            {
                Utils.SendError("Please enter a quantity of companies to generate!");
                var input = int.Parse(Console.ReadLine());

                if ((input) > 0)
                {
                    InitializeCompanies(input);
                }
                else
                {
                    InitializeGame(true);



                }
            }
            else {
                Console.WriteLine("Hello and welcome to TechTycoon! This is a story-based company generator. It is a C# console app, that is not really a game, but a certain level of enjoyment can be found in this application" +
                    "\n\n\r To begin, type in a valid quantity, this will be the number of companies we will generate");
                int input;
                bool worked = int.TryParse(Console.ReadLine(), out input);
                if (!worked)
                {
                    InitializeGame(true);
                }
                InitializeCompanies(input);
            }

        }

        public static void InitializeCompanies(int quantity)
        {
            float percentage;
            for(float i = 0; i < quantity; i++)
            {
                percentage = (int)Math.Round((i+1)/quantity*100);
                var generated = Companies.GenerateRandomCompany();
                Companies.Add(generated);
                Utils.UpdateMessage(generated.Name + " -  Type: " + generated.Type.Name + " " + percentage + "%");
            }
            Console.WriteLine("\n\nPlease enter a command:\n");


            HandleCommand();

        }


        public static void HandleCommand()
        {
            string input = string.Format(Console.ReadLine());
            if(input.Length == 0)
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
