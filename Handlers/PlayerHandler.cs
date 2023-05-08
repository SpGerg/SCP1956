using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SCP1956.Handlers
{
    public class PlayerHandler
    {
        public static void OnSpawned(SpawnedEventArgs args)
        {
            Player player = args.Player;

            if (player.Role == RoleTypeId.ClassD && player.UserId == Program.Instance.Config.SCP1956UserId)
            {
                player.Scale = new Vector3(1, 0.5f, 1);
                player.Health = 500;
            }
        }
    }
}
