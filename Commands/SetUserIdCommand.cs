using CommandSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCP1956.Commands
{
    public class SetUserIdCommand : ICommand
    {
        public string Command => "scp1956";

        public string[] Aliases => new string[] { };

        public string Description => "";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = "Айди " + arguments[0] + " установлен SCP-1956";

            return true;
        }
    }
}
