using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TechTyccoon2;
using TechTyccoon2.Providers;
using TechTyccoon2.Utilities;

namespace TechTyccoon2.Commands
{
    public class RecordsCommand : ICommand
    {
        public string Name { get; set; } = "Records";
        public string Description { get; set; } = "Retrieves a list of ALL records for a company!";
        public string Usecase { get; set; } = "records";

        public List<string> Aliases { get; set; } = new List<string>()
        {
            "finances",
            "records",
            "history",
            "past"
        };
        
        public void Execute(List<string> args = null)
        {
            int id;
            if(args.Count == 2)
            {
                id = int.Parse(args[1]);
            }
            else
            {
                Utils.SendError("Please enter a company ID! Ex. /history 666");
                return;
            }
            if(id <= 0)
            {
                Utils.SendError("Invalid company ID!");
                return;
            }

            Company c = Companies.SearchIndex(id-1);

            if (c.CompanyRecords.Count == 0)
            {
                Utils.SendError($"{c.Name} has no records currently! It must be a very new company.");
                return;
            }

            Console.WriteLine();
            Utils.SendCustom($"{c.Name}'s Yearly Records:", ConsoleColor.Green, false);

            foreach (CompanyRecord log in c.CompanyRecords) {
                if(log.NetGain < 0)
                {
                    Utils.SendCustom($"[{log.Year}] +{Math.Abs(log.NetGain)}", ConsoleColor.White, false);

                }
                else
                {
                    Utils.SendCustom($"[{log.Year}] -{log.NetGain}", ConsoleColor.Red, false);

                }

            }
        }
    }
}
