using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArenaSimulation
{
    public class Arena
    {
        private Warrior _warriorOne;
        private Warrior _warriorTwo;
        private Random _decisionPicker;

        public Arena(Warrior warriorOne, Warrior warriorTwo, Random decisionPicker)
        { 
            _warriorOne = warriorOne;
            _warriorTwo = warriorTwo;
            _decisionPicker = decisionPicker;
        }

        public void Fight()
        {
            bool battleOngoing = true;

            int gameTurn = 0;

            // Before battle both players will play Head Or Tail to decide who will attack first
            // But to make fair, a decision should be made between players to decide which side of coin to bet.

            // Warrior one = 0;
            // Warrior two = 1;
            int warriorToBet = _decisionPicker.Next(2);

            string warriorOneBet = string.Empty;
            string warriorTwoBet = string.Empty;
            string playerToAttack = string.Empty;

            if (warriorToBet == 0)
            {
                // Warrior one choosing a side
                warriorOneBet = HeadOrTail.FlipCoin(_decisionPicker);

                if (warriorOneBet == "Heads") 
                    warriorTwoBet = "Tails";
                else if (warriorOneBet == "Tails") 
                    warriorTwoBet = "Heads";
            }

            else
            {
                // Warrior two choosing a side
                warriorTwoBet = HeadOrTail.FlipCoin(_decisionPicker);

                if (warriorTwoBet.Equals("Heads")) 
                    warriorOneBet = "Tails";
                else if (warriorTwoBet.Equals("Tails")) 
                    warriorOneBet = "Heads";
            }

            // Now both players has selected their sides
            // It's time to flip the coin and see who will attack first
            string coinFlipResult = HeadOrTail.FlipCoin(_decisionPicker);

            if (warriorOneBet.Equals(coinFlipResult)) 
                playerToAttack = _warriorOne.GetWarriorName();
            else if (warriorTwoBet.Equals(coinFlipResult)) 
                playerToAttack= _warriorTwo.GetWarriorName();

            for (int countdown = 3; countdown >= 0; countdown--)
            {
                Announcer.Message($"\tBattle Start In: {countdown}", 1000, updateMessage: true, updateMessageAtPosition: 12);

                if (countdown == 0)
                    Announcer.Message($"\tFight!", 1000, updateMessage: true, updateMessageAtPosition: 12);
            }

            Announcer.Message($"\tFirst to attack {playerToAttack}", 1000, updateMessage: true, updateMessageAtPosition: 12, consoleColor: ConsoleColor.DarkYellow);

            do
            {
                if (gameTurn > 0)
                {
                    Announcer.Message($"\t{Messages.TurnIndicator(_decisionPicker.Next(4), playerToAttack)}", 15000, updateMessage: true, updateMessageAtPosition: 12, consoleColor: ConsoleColor.DarkYellow);
                    Announcer.Message(Announcer.RenderPlayerHpInfo($"{_warriorOne.GetHealth()} HP", $"{_warriorTwo.GetHealth()} HP"), 0, updateMessage: true, updateMessageAtPosition: 10);
                }

                // Clear battle message
                Announcer.Message(" ", 0, updateMessage: true, updateMessageAtPosition: 13);

                if (playerToAttack.Contains(_warriorOne.GetWarriorName()))
                {
                    int warriorOneAttack = _warriorOne.Attack();
                    int warriorTwoDefend = _warriorTwo.Defend();

                    if (warriorOneAttack > warriorTwoDefend)
                    {
                        Announcer.Message($"\t> {Messages.AttackMessages(warriorOneAttack, _warriorOne, _warriorTwo)}", 2000, updateMessage: true, updateMessageAtPosition: 13);
                    }
                    else
                    {
                        Announcer.Message($"\t> {Messages.DefenseMessages(warriorOneAttack, warriorTwoDefend, _warriorTwo, _warriorOne)}", 2000, updateMessage: true, updateMessageAtPosition: 13);
                    }

                    playerToAttack = _warriorTwo.GetWarriorName();
                }
                else
                {
                    int warriorTwoAttack = _warriorTwo.Attack();
                    int warriorOneDefend = _warriorOne.Defend();

                    if (warriorTwoAttack > warriorOneDefend)
                    {
                        Announcer.Message($"\t> {Messages.AttackMessages(warriorTwoAttack, _warriorTwo, _warriorOne)}", 2000, updateMessage: true, updateMessageAtPosition: 13);
                    }
                    else
                    {
                        Announcer.Message($"\t> {Messages.DefenseMessages(warriorTwoAttack, warriorOneDefend, _warriorOne, _warriorTwo)}", 2000, updateMessage: true, updateMessageAtPosition: 13);
                    }

                    playerToAttack = _warriorOne.GetWarriorName();
                }

                Announcer.Message(Announcer.RenderPlayerHpInfo($"{_warriorOne.GetHealth()} HP {_warriorOne.GetHPUpdate()}", $"{_warriorTwo.GetHPUpdate()} {_warriorTwo.GetHealth()} HP"), 0, updateMessage: true, updateMessageAtPosition: 10);

                if (!_warriorOne.Alive() || !_warriorTwo.Alive())
                {
                    Announcer.Message("\t=== Game Over ===", 3000, updateMessage: true, updateMessageAtPosition: 15);

                    if (_warriorOne.Alive())
                    {
                        Announcer.Message($"\t{_warriorOne.GetWarriorName()} wins!", 0, updateMessage: true, updateMessageAtPosition: 17, consoleColor: ConsoleColor.Green);
                        Announcer.Message($"\t{_warriorOne.GetWarriorName()} - \"{_warriorOne.GetWinningMessage()}\"", 0, updateMessage: true, updateMessageAtPosition: 18, consoleColor: ConsoleColor.Green);
                        
                        Announcer.SetChampion(_warriorOne.GetWarriorName());

                        Announcer.Message($"\t{_warriorTwo.GetWarriorName()} eliminated!", 0, updateMessage: true, updateMessageAtPosition: 20, consoleColor: ConsoleColor.Red);
                        Announcer.Message($"\t{_warriorTwo.GetWarriorName()} - \"{_warriorTwo.GetLostInGameMessage()}\"", 0, updateMessage: true, updateMessageAtPosition: 21, consoleColor: ConsoleColor.Red);
                    }
                    else
                    {
                        Announcer.Message($"\t{_warriorTwo.GetWarriorName()} wins!", 0, updateMessage: true, updateMessageAtPosition: 17, consoleColor: ConsoleColor.Green);
                        Announcer.Message($"\t{_warriorTwo.GetWarriorName()} - \"{_warriorTwo.GetWinningMessage()}\"", 0, updateMessage: true, updateMessageAtPosition: 18, consoleColor: ConsoleColor.Green);

                        Announcer.SetChampion(_warriorTwo.GetWarriorName());

                        Announcer.Message($"\t{_warriorOne.GetWarriorName()} eliminated!", 0, updateMessage: true, updateMessageAtPosition: 20, consoleColor: ConsoleColor.Red);
                        Announcer.Message($"\t{_warriorOne.GetWarriorName()} - \"{_warriorOne.GetLostInGameMessage()}\"", 0, updateMessage: true, updateMessageAtPosition: 21, consoleColor: ConsoleColor.Red);
                    }

                    battleOngoing = false;
                }
                else
                { 
                    gameTurn += 1;
                }

            } while (battleOngoing);
        }
    }
}
