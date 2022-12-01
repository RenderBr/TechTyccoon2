using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTyccoon2.Utilities;

namespace TechTyccoon2
{
    public interface ICommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Aliases { get; set; }

        public string Usecase { get; set; }

        public void Execute(List<string> args = null)
        {
            Utils.SendError("This command has not yet been implemented!");
        }
    }
}
