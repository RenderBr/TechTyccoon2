using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTyccoon2;
using TechTyccoon2.Providers;
using TechTyccoon2.Utilities;

namespace TechTyccoon2.Commands
{
    public class TopCommand : ICommand
    {
        public string Name { get; set; } = "Top";
        public string Description { get; set; } = "Retrieves the top ten companies with the highest net worth.";
        public string Usecase { get; set; } = "top (quantity) | ex. top 50";

        public List<string> Aliases { get; set; } = new List<string>()
        {
            "top",
            "leaderboard",
            "best"
        };
        
        public void Execute(List<string> args = null)
        {
            int quantity = 10;

            if(args.Count == 2)
            {
                quantity = int.Parse(args[1]);
            }

            List<Company> top = Companies.companies.ToList();
            top = top.FindAll(x => x.Defunct == false);
            top = top.OrderBy(x=>x.CurrentFunds).ToList();
            top = top.Reverse<Company>().ToList();
            top = top.GetRange(0, quantity);
            Utils.SendCustom($"Top {quantity} companies in current simulation:", ConsoleColor.Yellow, false);
        
            foreach(Company company in top)
            {
                Utils.SendCustom($"[{top.IndexOf(company)+1}] [CID: {Companies.companies.IndexOf(company)+1}] - {company.Name} - ${company.CurrentFunds}", ConsoleColor.White, false);

            }
        }
    }
}
