using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTyccoon2.Commands
{
    public class ClearCommand : ICommand
    {
        public string Name { get; set; } = "Clear";

        public string Description { get; set; } = "Clears the entire console.";

        public string Usecase { get; set; } = "clear";

        public List<string> Aliases { get; set; } = new List<string>()
        {
            "clear",
            "clearconsole"
        };
        
        public void Execute(List<string> args = null)
        {
            Console.Clear();
        }
    }
}
