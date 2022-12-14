using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TechTyccoon2.Commands;
using TechTyccoon2;
using TechTyccoon2.Providers;
using TechTyccoon2.Utilities;

namespace TechTyccoon2
{
    public static class CommandHandler
    {
        public static List<ICommand> CmdList = new List<ICommand>() {
            Commands.Clear,
            Commands.Help,
            Commands.Progress,
            Commands.Search,
            Commands.Time,
            Commands.Top,
            Commands.Active,
            Commands.Records,
            Commands.Exit
        };
 
       public static void HandleCommand(List<string> args)
        {
            if (args.Count == 0)
            {
                GameManager.HandleCommand();
                return;
            }

            string command = args[0];
            var cmd = CmdList.FirstOrDefault(x => x.Aliases.Contains(command));
            if(cmd == null)
            {
                Utils.SendError("Invalid command!");
                GameManager.HandleCommand();
            }

            cmd.Execute(args);

        }

        public static class Commands
        {
            public static ClearCommand Clear = new ClearCommand();
            public static HelpCommand Help = new HelpCommand();
            public static ProgressCommand Progress = new ProgressCommand();
            public static SearchCommand Search = new SearchCommand();
            public static TimeCommand Time = new TimeCommand();
            public static TopCommand Top = new TopCommand();
            public static ActiveCommand Active = new ActiveCommand();
            public static RecordsCommand Records = new RecordsCommand();
            public static ExitCommand Exit = new ExitCommand();
        }





    }
}
