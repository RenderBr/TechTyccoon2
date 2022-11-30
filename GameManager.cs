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

                }
                else
                {
                    InitializeGame(true);



                }
            }
            else {
                Console.WriteLine("Hello and welcome to TechTycoon! This is a story-based company generator. It is a C# console app, that is not really a game, but a certain level of enjoyment can be found in this application" +
                    "\n\n To begin, type in a valid quantity, this will be the number of companies we will generate");
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


            CommandHandler();

        }

        public static void ProgressTime(int years)
        {
            Console.Clear();
            Random r = new Random();


            for(var i = 0; i < years;i++)
            {
                foreach(Company c in Companies.companies)
                {
                    float netGain = 0;

                    double percentage = r.NextDouble();

                    if(c.SuccessRate-percentage <= 0)
                    {
                        Console.WriteLine("profit! " + c.SuccessRate + " " + percentage);
                    }

                //    c.CompanyRecords.Add(new CompanyRecord(c.Index(), Year, ));
                }

            }

        }

        public static void CommandHandler()
        {
            string input = string.Format(Console.ReadLine());
            if(input.Length == 0)
            {
                CommandHandler();
            }
            List<string> args = new List<string>();

            args = Utils.ParseParameters(input);
            if(args.Count == 0)
            {
                CommandHandler();
            }

            string command = args[0];

            switch (command)
            {
                case ("search"):
                {
                     if (args.Count == 2)
                    {
                            bool succeeded;
                            int i;
                            succeeded = int.TryParse(args[1], out i);

                            if (succeeded == false)
                            {
                                Utils.SendError("Invalid company id!");
                                break;
                            }
                            if (i >= Companies.Count())
                            {
                                Utils.SendError("Invalid company id!");
                                break;
                            }


                        Company Company = Companies.SearchIndex(i-1);
                        Console.WriteLine($"{Company.Name}\n - Balance: ${Company.CurrentFunds}\n");
                        CommandHandler();
                        break;
                        }
                        else
                        {
                            Utils.SendError("Please enter some arguments for search! Ex: search <company id>");
                            CommandHandler();
                            break;
                        }
                    }
                case ("progress"):
                    {
                        int progress = 0;
                        if (args.Count == 2)
                        {
                            progress = int.Parse(args[1]);
                        }
                        else
                        {
                            progress++;
                        }
                        ProgressTime(progress);
                        Utils.SendSuccess($"You have progressed time by {progress} years!");

                        break;
                    }
                case ("time"):
                    {
                        Utils.SendCustom($"This simulation is on Year {Year}", ConsoleColor.Yellow);
                        break;
                    }
                case ("clear"):
                    {
                        Console.Clear();
                        break;
                    }
                default:
                    {
                        Utils.SendError("Invalid command!");
                        CommandHandler();
                        break;
                    }
            
                   
                  
            }
            CommandHandler();
                
        }

            
            
        }

    }
