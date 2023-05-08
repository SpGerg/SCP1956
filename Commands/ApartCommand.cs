using CommandSystem;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using RemoteAdmin;
using System;

namespace SCP1956.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class ApartCommand : ICommand
    {
        public string Command => "apart";

        public string[] Aliases => new string[] { };

        public string Description => "";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!(sender is PlayerCommandSender))
            {
                response = "Только в игровой консоли, друг!";

                return true;
            }

            Player player = Player.Get(sender);

            if (player.UserId == Program.Instance.Config.SCP1956UserId)
            {
                Item itemInHand = player.CurrentItem;
                string userId = player.UserId;
                int points;
                
                if (itemInHand == null)
                {
                    response = "Твоя рука пуста, друг! Возьми что-то в руки.";

                    return true;
                }

                if (!Program.Instance.Config.ItemsWithPrice.ContainsKey(itemInHand.Type.ToString()))
                {
                    response = "Неизвестный предмет.";

                    return true;
                }

                points = Program.Instance.Config.ItemsWithPrice[itemInHand.Type.ToString()];

                if (!Program.Points.ContainsKey(userId)) Program.Points.Add(userId, 0);
                Program.Points[userId] += points;

                response = "За этот предмет я дам: " + points + " очков.\nУ тебя очков: " + Program.Points[userId];

                itemInHand.Destroy();

                return true;
            }

            response = "Ты не тот за кого себя выдаёшь! " + player.UserId + " " + Program.Instance.Config.SCP1956UserId;

            return true;
        }
    }
}
