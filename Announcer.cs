using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArenaSimulation
{
    public class Announcer
    {
        private static string? _winningPlayer;

        public static void Message(string message, int timeBeforeMessageShow, bool newLine = true, bool updateMessage = false, int updateMessageAtPosition = 0, ConsoleColor consoleColor = ConsoleColor.White)
        {
            Thread.Sleep(timeBeforeMessageShow);

            Console.ForegroundColor = consoleColor;

            if (updateMessage)
            {
                int currentLineCursor = Console.CursorTop;

                Console.SetCursorPosition(0, updateMessageAtPosition);

                Console.Write($"\r{message.PadRight(Console.LargestWindowWidth - 1)}");

                Console.SetCursorPosition(0, currentLineCursor);
            }
            else
            {
                if (newLine)
                    Console.WriteLine(message);
                else
                    Console.Write(message);
            }

            if (consoleColor != ConsoleColor.White) Console.ResetColor();
        }

        public static void SetChampion(string winningPlayer)
        {
            _winningPlayer = winningPlayer;
        }

        public static string GetChampion()
        { 
            return _winningPlayer;
        }

        public static string RenderPlayerInfo(string playerOne, string playerTwo, bool nextLine = false)
        {
            int maxChar = 20;
            return $"\t{playerOne.PadRight(maxChar)}\tV.S\t{playerTwo.PadLeft(maxChar)}";
        }

        public static string RenderPlayerHpInfo(string playerOne, string playerTwo, bool nextLine = false)
        {
            int maxChar = 20;

            return $"\t{playerOne.PadRight(maxChar)}\t\t{playerTwo.PadLeft(maxChar)}";
        }
    }
}
