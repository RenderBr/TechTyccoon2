using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TechTyccoon2;
using TechTyccoon2.Providers;
using TechTyccoon2.Utilities;

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
                    if(c.Defunct)
                    {
                        continue;
                    }
                    if (c.CurrentFunds <= 1)
                    {
                        c.Defunct = true;
                        Utils.SendCustom($"{c.Name} has gone out of business! R.I.P (Year: {GameManager.Year})", ConsoleColor.Yellow);
                        c.EmployeeCount = 0;
                        continue;
                    }
                    double initial = c.CurrentFunds;
                    double netGain;

                    double percentage = r.NextDouble();

                    if(c.SuccessRate >= 1)
                    {
                        c.SuccessRate = 0.95;
                    }

                    var chance = percentage - c.SuccessRate;


                    if(r.NextDouble() < 0.5 && !GameManager.ProductionManager.InstancedProducts.Any(x=>x.Owner == c && x.Released == false))
                    {
                        GameManager.ProductionManager.CreateProduct(c);
                    }
                    else if(GameManager.ProductionManager.InstancedProducts.Any(x=>x.Owner == c && x.Released == false))
                    {
                        GameManager.ProductionManager.FurtherProduct(GameManager.ProductionManager.InstancedProducts.First(x => x.Owner == c && x.Released == false));
                    }

                    GameManager.ProductionManager.ApplySales(c);

                    if (chance >= 0)
                    {
                        //lose
                        c.CurrentFunds -= (c.CurrentFunds * 0.1);
                        double loss = initial - c.CurrentFunds;
                        c.CompanyRecords.Add(new CompanyRecord(GameManager.Year, (int)loss));
                        c.EmployeeCount -= (int)Math.Round(c.EmployeeCount * 0.25);
                        c.SuccessRate -= (c.SuccessRate * 0.1);

                    }
                    else if (chance <= 0)
                    {
                        //win
                        c.CurrentFunds += (c.CurrentFunds * 0.1);
                        double gain = initial - c.CurrentFunds;
                        c.CompanyRecords.Add(new CompanyRecord(GameManager.Year, (int)gain));
                        c.EmployeeCount += (int)Math.Round(c.EmployeeCount * 0.25);
                        c.SuccessRate += (c.SuccessRate * 0.1);

                    }
                    else
                    {
                        //none
                    }

                    if(c.CurrentFunds <= 1)
                    {
                        c.Defunct = true;
                        Utils.SendCustom($"[CID: {Companies.companies.IndexOf(c)}] {c.Name} has gone out of business! R.I.P (Year: {GameManager.Year})", ConsoleColor.Yellow);
                    }
               
                }
                GameManager.Year++;


            }


        }

    }
}
