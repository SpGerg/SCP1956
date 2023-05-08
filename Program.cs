using Exiled.API.Features;
using SCP1956.Handlers;
using System.Collections.Generic;

using Player = Exiled.Events.Handlers.Player;
using Server = Exiled.Events.Handlers.Server;

namespace SCP1956
{
    public class Program : Plugin<Config>
    {
        public static Dictionary<string, int> Points = new Dictionary<string, int>();

        private static readonly Program Singleton = new Program();

        public static Program Instance => Singleton;

        public override void OnEnabled()
        {
            Player.Spawned += PlayerHandler.OnSpawned;

            Server.RestartingRound += ServerHandler.OnRestart;

            base.OnEnabled();
        }
    }
}
