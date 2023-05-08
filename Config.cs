using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCP1956
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; }

        public string SCP1956UserId { get; set; } = "76561198980711126@steam";

        public Dictionary<string, int> ItemsWithPrice { get; set; } = new Dictionary<string, int>
        {
            { "SCP018", 25 },
            { "SCP500", 30 },
            { "SCP2176", 20 },
            { "SCP207", 30 },
            { "SCP330", 10 },
            { "Adrenaline", 15 },
            { "Coin", 15 },
            { "Flashlight", 10 },
            { "Medkit", 15 },
            { "SCP268", 50 },
            { "MicroHID", 125 }
        };

        public List<ItemType> ItemsBadVariant { get; set; } = new List<ItemType>
        {
            ItemType.Coin,
            ItemType.Flashlight,
            ItemType.Radio,
            ItemType.KeycardJanitor,
            ItemType.Medkit,
            ItemType.Adrenaline
        };
    }
}
