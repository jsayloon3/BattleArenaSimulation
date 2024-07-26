using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArenaSimulation
{
    public class Helper
    {
        public static string ConvertGenderToPossessivePronoun(string gender, int attackType = 0, int defenseType = 0)
        {
            if (gender.Equals("male") && (attackType == 1 || attackType == 4 || attackType == 7 || attackType == 9 || attackType == 10) || (defenseType == 6 || defenseType == 7 || defenseType == 9 || defenseType == 10)) return "his";
            else if (gender.Equals("male")) return "him";
            else return "her";
        }

        public static string ConvertGenderToGenderedProunoun(string gender)
        { 
            return gender.Equals("male") ? "he" : "she";
        }

        public static string ConvertGenderToReflexivePronoun(string gender)
        { 
            return gender.Equals("male") ? "himself" : "herself";
        }
    }
}
