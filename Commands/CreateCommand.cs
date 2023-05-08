using CommandSystem;
using Exiled.API.Features;
using InventorySystem.Items;
using RemoteAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SCP1956.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class CreateCommand : ICommand
    {
        public string Command => "create";

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

            System.Random random = new System.Random();

            KeyValuePair<string, int> item = Program.Instance.Config.ItemsWithPrice
                .OrderBy(x => Math.Abs(x.Value - Program.Points[player.UserId]))
                .ElementAt(0);

            if (random.Next(0, 10) <= 5)
            {
                response = "Ну, тебе повезло! Получшай: " + item.Key;

                player.AddItem((ItemType)Enum.Parse(typeof(ItemType), item.Key));
            }
            else
            {
                int divideOnThree = (int)Program.Points[player.UserId] / 3;
                int divideOnFive = (int)Program.Points[player.UserId] / 5;

                string itemName = "Неизвестно";

                if (divideOnFive > divideOnThree)
                {
                    int itemToGive = random.Next(0, (int) Program.Instance.Config.ItemsBadVariant.Count / 2);

                    for (int i = 0; i < divideOnFive; i++)
                    {
                        ItemType itemType = Program.Instance.Config.ItemsBadVariant[itemToGive];
                        player.AddItem(itemType);
                        itemName = itemType.ToString();
                    }
                }
                else
                {
                    int itemToGive = random.Next((int) Program.Instance.Config.ItemsBadVariant.Count / 2, Program.Instance.Config.ItemsBadVariant.Count);

                    for (int i = 0; i < divideOnFive; i++)
                    {
                        ItemType itemType = Program.Instance.Config.ItemsBadVariant[itemToGive];
                        player.AddItem(itemType);
                        itemName = itemType.ToString();
                    }
                }

                response = "Ну, не повезло! Получшай несколько: " + itemName;
            }

            Program.Points[player.UserId] = 0;

            return true;
        }
    }
}
