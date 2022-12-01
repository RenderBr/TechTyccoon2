using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTyccoon2.Commands
{
    public class ProgressCommand : ICommand 
    {
        public string Name { get; set; } = "Progress";
        public string Description { get; set; } = "Progresses a set amount of time in years, defaults to one year.";
        public string Usecase { get; set; } = "progress (years)";

        public List<string> Aliases { get; set; } = new List<string>()
        {
            "p",
            "next",
            "progress",
            "further"
        };

        public void Execute(List<string> args = null) {
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
        }


        public static void ProgressTime(int years)
        {
            Random r = new Random();


            for (var i = 0; i < years; i++)
            {
                foreach (Company c in Companies.companies)
                {
                    float netGain = 0;

                    double percentage = r.NextDouble();

                    if (c.SuccessRate - percentage <= 0)
                    {
                        c.CurrentFunds += (c.SuccessRate * r.Next(1, (int)c.CurrentFunds));
                        Console.WriteLine("profit! " + c.SuccessRate + " " + percentage);
                    }

                    //    c.CompanyRecords.Add(new CompanyRecord(c.Index(), Year, ));
                }

            }

        }

    }
}
