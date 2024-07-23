using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArenaSimulation
{
    public class HeadOrTail
    {
        public static string FlipCoin(Random coin)
        {
            return coin.Next(2) == 0 ? "Heads" : "Tails";
        }
    }
}
