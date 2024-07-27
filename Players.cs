using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArenaSimulation
{
    public class Players
    {
        public class WarriorModel
        {
            public string? name { get; set; }
            public string? gender { get; set; }
            public List<string>? messages_when_win { get; set; }
            public List<string>? messages_when_defeated { get; set; }
        }
    }
}
