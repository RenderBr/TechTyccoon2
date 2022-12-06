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
    public class ActiveCommand : ICommand
    {
        public string Name { get; set; } = "Active";
        public string Description { get; set; } = "Displays the total quantity of active (non-defunct) companies.";
        public string Usecase { get; set; } = "active";

        public List<string> Aliases { get; set; } = new List<string>()
        {
            "active",
            "left"
        };
        
        public void Execute(List<string> args = null)
        {
          List<Company> list = Companies.companies.FindAll(x => !x.Defunct);

            

          Utils.SendCustom($"There are {list.Count} active companies on this simulation!", ConsoleColor.Yellow);
            
        }
    }
}
