using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTyccoon2.Commands
{
    public class HelpCommand : ICommand
    {
        public string Name { get; set; } = "Help";
        public string Description { get; set; } = "Retrieves a list of all commands and their usecase.";
        public string Usecase { get; set; } = "help (command)";

        public List<string> Aliases { get; set; } = new List<string>()
        {
            "help",
            "commands",
            "?"
        };
        
        public void Execute(List<string> args = null)
        {
            if(args.Count == 2)
            {
                var cmd = CommandHandler.CmdList.FirstOrDefault(x => x.Aliases.Contains(args[1]));
                Utils.SendCustom($"'{cmd.Name}': {cmd.Description}", breakline:false);
            }
            else
            {
                Utils.SendCustom("List of useable commands: ", ConsoleColor.Yellow);
                foreach (ICommand cmd in CommandHandler.CmdList) {
                    Utils.SendCustom($"{cmd.Name} - {cmd.Description} // how to use: {cmd.Usecase}", breakline: false);
                }
                
            }
        }
    }
}
