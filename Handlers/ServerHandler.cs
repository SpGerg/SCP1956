using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCP1956.Handlers
{
    public class ServerHandler
    {
        public static void OnRestart()
        {
            Program.Points.Clear();
        }
    }
}
