using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArenaSimulation
{
    public class Players
    {
        public static List<string> List()
        {
            var players = new List<string>()
            {
                "Luminex",
                "Sonic Surge",
                "Nebula Knight",
                "Tempest Strider",
                "Aether Sentinel",
                "Vortex Vanguard",
                "Celestial Ember",
                "Chrono Warden",
                "Galactic Scepter",
                "Phoenix Nova"
            };

            return players;
        }
    }
}
