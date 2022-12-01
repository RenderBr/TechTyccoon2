using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTyccoon2.Commands
{
    public class SearchCommand : ICommand
    {
        public string Name { get; set; } = "Search";
        public string Description { get; set; } = "Searches for a company ID and retrieves a user's information.";
        public string Usecase { get; set; } = "search (comp. id)";

        public List<string> Aliases { get; set; } = new List<string>()
        {
            "search",
            "cinfo",
            "company",
            "see"
        };
        
        public void Execute(List<string> args = null)
        {
            if (args.Count == 2)
            {
                bool succeeded;
                int i;
                succeeded = int.TryParse(args[1], out i);

                if (succeeded == false)
                {
                    Utils.SendError("Invalid company id!");
                    return;
                }
                if (i >= Companies.Count()+1)
                {
                    Utils.SendError("Invalid company id!");
                    return;
                }
                if(i <= 0)
                {
                    Utils.SendError("Invalid company id!");
                    return;
                }


                Company Company = Companies.SearchIndex(i - 1);
                Console.WriteLine($"{Company.Name}\n - Balance: ${Company.CurrentFunds}\n");
                GameManager.HandleCommand();
                return;
            }
            else
            {
                Utils.SendError("Please enter some arguments for search! Ex: search <company id>");
                GameManager.HandleCommand();
                return;
            }
        }
    }
}
