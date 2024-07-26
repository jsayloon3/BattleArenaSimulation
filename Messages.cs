using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArenaSimulation
{
    public class Messages
    {
        public static string AttackMessages(int attackType, Warrior playerOne, Warrior playerTwo)
        {
            string message = "";
            switch (attackType) 
            { 
                // Normal Attack
                case 1: 
                    message = $"{playerOne.GetWarriorName()} swung {Helper.ConvertGenderToPossessivePronoun(playerOne.GetWarriorGender(), 1)} sword with precision, striking {playerTwo.GetWarriorName()} with a well-placed hit.";
                    playerTwo.DamageTaken(1);
                    break;
                // Magic Attack
                case 2:
                    message = $"{playerOne.GetWarriorName()} cast a fireball spell, engulfing {playerTwo.GetWarriorName()} in flames and causing significant damage.";
                    playerTwo.DamageTaken(2);
                    break;
                // Ranged Attack
                case 3:
                    message = $"{playerOne.GetWarriorName()} notched an arrow and let it fly, hitting {playerTwo.GetWarriorName()} from a distance with pinpoint accuracy.";
                    playerTwo.DamageTaken(3);
                    break;
                // Special Attack
                case 4:
                    message = $"{playerOne.GetWarriorName()} summoned {Helper.ConvertGenderToPossessivePronoun(playerOne.GetWarriorGender(), 4)} inner strength, launching a devastating special attack that took {playerTwo.GetWarriorName()} by surprise.";
                    playerTwo.DamageTaken(4);
                    break;
                // Combo Attack
                case 5:
                    message = $"{playerOne.GetWarriorName()} executed a series of swift moves, landing a flurry of hits on {playerTwo.GetWarriorName()} in a seamless combo.";
                    playerTwo.DamageTaken(5);
                    break;
                // Area of Effect Attack:
                case 6:
                    message = $"{playerOne.GetWarriorName()} unleashed a shockwave, hitting {playerTwo.GetWarriorName()} and all nearby enemies with a powerful blast.";
                    playerTwo.DamageTaken(6);
                    break;
                // Poison Attack
                case 7:
                    message = $"{playerOne.GetWarriorName()} dipped {Helper.ConvertGenderToPossessivePronoun(playerOne.GetWarriorGender(), 7)} blade in poison before slashing {playerTwo.GetWarriorName()}, leaving {Helper.ConvertGenderToPossessivePronoun(playerTwo.GetWarriorGender())} with a lingering, harmful effect.";
                    playerTwo.DamageTaken(7);
                    break;
                // Sneak Attack
                case 8:
                    message = $"{playerOne.GetWarriorName()} crept up silently behind {playerTwo.GetWarriorName()}, delivering a surpise attack that caught {Helper.ConvertGenderToPossessivePronoun(playerTwo.GetWarriorGender())} off guard.";
                    playerTwo.DamageTaken(8);
                    break;
                // Elemental Attack
                case 9:
                    message = $"{playerOne.GetWarriorName()} harnessed the power of lightning, striking {playerTwo.GetWarriorName()} with a bolt that electrified {Helper.ConvertGenderToPossessivePronoun(playerTwo.GetWarriorGender(), 9)} entire body.";
                    playerTwo.DamageTaken(9);
                    break;
                // Heavy Attack
                case 10:
                    message = $"{playerOne.GetWarriorName()} charged {Helper.ConvertGenderToPossessivePronoun(playerOne.GetWarriorGender(), 10)} weapon with all {Helper.ConvertGenderToPossessivePronoun(playerOne.GetWarriorGender(), 10)} strength, delivering a crushing blow that sent {playerTwo.GetWarriorName()} staggering back.";
                    playerTwo.DamageTaken(10);
                    break;
                default:
                    message = $"{playerOne.GetWarriorName()} attacked with passive skill absolutely no damage";
                    break;
            }

            return message;
        }

        public static string DefenseMessages(int attackType, int defenseType, Warrior playerOne, Warrior playerTwo)
        {
            string message = "";
            switch (defenseType)
            {
                // Normal Defense
                case 1:
                    message = $"{playerOne.GetWarriorName()} raised {Helper.ConvertGenderToPossessivePronoun(playerOne.GetWarriorGender(), 1)} shield, blocking {playerTwo.GetWarriorName()}'s attack with solid defense.";
                    playerOne.DamageTaken(0);
                    break;
                // Dodge
                case 2:
                    message = $"{playerOne.GetWarriorName()} nimbly sidestepped {playerTwo.GetWarriorName()}'s strike, avoiding the attack entirely.";
                    playerOne.DamageTaken(0);
                    break;
                // Counter
                case 3:
                    message = $"{playerOne.GetWarriorName()} deflected {playerTwo.GetWarriorName()}'s blow and quickly retaliated with counterattack.";
                    playerOne.DamageTaken(attackType);
                    playerTwo.DamageTaken(attackType);
                    break;
                // Magic Shield
                case 4:
                    message = $"{playerOne.GetWarriorName()} conjured a magical barrier, absorbing the impact of {playerTwo.GetWarriorName()}'s spell and minimizing the damage.";
                    playerOne.DamageTaken(1);
                    break;
                // Evasion
                case 5:
                    message = $"{playerOne.GetWarriorName()} performed a swift roll, narrowly evading {playerTwo.GetWarriorName()}'s attack and staying out of harm's way.";
                    playerOne.HealthRecovery(2);
                    break;
                // Reflect
                case 6:
                    message = $"{playerOne.GetWarriorName()} activated {Helper.ConvertGenderToPossessivePronoun(playerOne.GetWarriorGender(), 0, 6)} reflective shield, bouncing {playerTwo.GetWarriorName()}'s attack back at {Helper.ConvertGenderToPossessivePronoun(playerTwo.GetWarriorGender())}.";
                    playerTwo.DamageTaken(attackType);
                    break;
                // Absorption
                case 7:
                    message = $"{playerOne.GetWarriorName()} used {Helper.ConvertGenderToPossessivePronoun(playerOne.GetWarriorGender(), 0, 7)} absorbent aura to soak up the energy from {playerTwo.GetWarriorName()}'s attack, reducing the damage.";
                    playerOne.DamageTaken(attackType - 3);
                    break;
                // Barrier
                case 8:
                    message = $"{playerOne.GetWarriorName()} summoned an energy barrier, creating a protective wall that absorbed {playerTwo.GetWarriorName()}'s strike.";
                    playerOne.DamageTaken(0);
                    playerOne.HealthRecovery(1);
                    break;
                // Fortify
                case 9:
                    message = $"{playerOne.GetWarriorName()} fortified {Helper.ConvertGenderToPossessivePronoun(playerOne.GetWarriorGender(), 0, 9)} defenses with an enhanced protective field, significantly reducing the damage from {playerTwo.GetWarriorName()}'s attack.";
                    playerOne.DamageTaken(attackType - 4);
                    break;
                // Ultimate Shield
                case 10:
                    message = $"{playerOne.GetWarriorName()} invoked {Helper.ConvertGenderToPossessivePronoun(playerOne.GetWarriorGender(), 0, 10)} ultimate shield, enveloping {Helper.ConvertGenderToReflexivePronoun(playerOne.GetWarriorGender())} in an impenetrable force field that nullified {playerTwo.GetWarriorName()}'s attack completely.";
                    playerOne.DamageTaken(0);
                    break;
                default:
                    message = $"{playerOne.GetWarriorName()} used weak defense and was hit by {playerTwo.GetWarriorName()}";
                    playerOne.DamageTaken(1);
                    break;
            }

            return message;
        }

        public static string TurnIndicator(int indicator, string playerName)
        {
            string message = "";
            switch (indicator)
            {
                case 0:
                    message = $"{playerName}'s turn";
                    break;
                case 1:
                    message = $"It's {playerName}'s turn";
                    break;
                case 2:
                    message = $"Now it's {playerName}'s move";
                    break;
                case 3:
                    message = $"{playerName}'s move";
                    break;
            }

            return message;
        }
    }
}
