using CommandSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCP1956.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class SetUserIdCommand : ICommand
    {
        public string Command => "scp1956";

        public string[] Aliases => new string[] { };

        public string Description => "";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = "Айди " + arguments.Array[0] + " установлен SCP-1956";

            Program.Instance.Config.SCP1956UserId = arguments.Array[0];

            return true;
        }
    }
}
