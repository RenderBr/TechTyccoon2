using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTycoon2;

namespace TechTyccoon2.Commands
{
    public class ExitCommand : ICommand
    {
        public string Name { get; set; } = "Exit";

        public string Description { get; set; } = "Exits the game and closes the program.";

        public string Usecase { get; set; } = "exit";

        public List<string> Aliases { get; set; } = new List<string>()
        {
            "exit",
            "off",
            "stop",
            "close"
        };
        
        public void Execute(List<string> args = null)
        {
            System.Environment.Exit(0);
        }
    }
}
