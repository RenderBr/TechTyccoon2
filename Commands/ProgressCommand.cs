using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    if(c.Defunct == true)
                    {
                        continue;
                    }
                    if (c.CurrentFunds <= 1)
                    {
                        c.Defunct = true;
                        c.EmployeeCount = 0;
                        continue;
                    }
                    if(c.EmployeeCount <= 0)
                    {
                        c.Defunct = true;
                        continue;
                    }
                    int initial = (int)c.CurrentFunds;
                    double netGain;

                    double percentage = r.NextDouble();

                    if(c.SuccessRate >= 1)
                    {
                        c.SuccessRate = 0.95;
                    }

                    if (percentage < c.SuccessRate)
                    {
                        c.CurrentFunds += Utils.Random((int)Math.Min(1, c.CurrentFunds), (int)Math.Abs(c.CurrentFunds));
                        c.SuccessRate += 0.025;
                        c.EmployeeCount += Utils.Random(c.EmployeeCount-(c.EmployeeCount+1), (int)(c.EmployeeCount));
                    }
                    else
                    {

                        c.CurrentFunds += Utils.Random((int)Math.Min(1, c.CurrentFunds), (int)Math.Abs(c.CurrentFunds));
                        c.SuccessRate -= 0.025;
                        c.EmployeeCount -= Utils.Random(c.EmployeeCount - (c.EmployeeCount + 1), (int)(c.EmployeeCount));
                    }
                    if (c.CurrentFunds <= 1)
                    {
                        c.Defunct = true;
                        c.EmployeeCount = 0;
                        continue;
                    }
                    netGain = (initial - (int)c.CurrentFunds);
                    Console.WriteLine("Initial: " + initial + " Current:" + c.CurrentFunds + " Net: " + netGain);
                    if(netGain < 0)
                    {
                        c.CompanyRecords.Add(new CompanyRecord(c.Index(), GameManager.Year, (int)Math.Abs(netGain)));
                    }
                    else if(netGain == 0)
                    {
                        c.CompanyRecords.Add(new CompanyRecord(c.Index(), GameManager.Year, 0));

                    }
                    else if(netGain > 0)
                    {
                        c.CompanyRecords.Add(new CompanyRecord(c.Index(), GameManager.Year, (int)-netGain));
                    }

                }
                GameManager.Year++;


            }


        }

    }
}
