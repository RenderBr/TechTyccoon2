using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTyccoon2.Commands
{
    public class TimeCommand : ICommand
    {
        public string Name { get; set; } = "Time";
        public string Description { get; set; } = "Retrieves the current year.";
        public string Usecase { get; set; } = "time";

        public List<string> Aliases { get; set; } = new List<string>()
        {
            "time",
            "year",
            "t",
            "when"
        };
        
        public void Execute(List<string> args = null)
        {
          Utils.SendCustom($"This simulation is on Year {GameManager.Year}", ConsoleColor.Yellow);
            
        }
    }
}
