using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTyccoon2.Utilities;

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

                    Company c = Companies.SearchName(args[1].ToLower());
                    if(c == null)
                    {
                        Utils.SendError("Invalid company name!");
                        return;
                    }

                    if (c.Defunct == true)
                    {
                        Utils.SendError($"{c.Name}, located in {c.Location}, has gone out of business! Overall, they went under: ${c.CurrentFunds} in funds.");
                        return;
                    }
                    Console.WriteLine($"\n{c.Name}\n - Balance: ${c.CurrentFunds}\n - Industry: {c.Industry.Name} \n - Located in: {c.Location}\n - Employees: {c.EmployeeCount}");
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
                if(Company.Defunct == true)
                {
                    Utils.SendError($"{Company.Name}, located in {Company.Location}, has gone out of business! Overall, they went under: ${Company.CurrentFunds} in funds.");
                    return;
                }
                Console.WriteLine($"\n{Company.Name}\n - Balance: ${Company.CurrentFunds}\n - Industry: {Company.Industry.Name} \n - Located in: {Company.Location}\n - Employees: {Company.EmployeeCount}");
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
