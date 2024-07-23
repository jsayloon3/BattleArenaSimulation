using BattleArenaSimulation;
using System.Runtime.InteropServices;

Console.Title = "Battle Arena Simulation";
Console.CursorVisible = false;


//Console.SetWindowSize(Console.LargestWindowWidth - 50, Console.LargestWindowHeight - 10);

// Intro
Announcer.Message("\n\t[ Initializing Game ]", 0);
Announcer.Message("\t[ Starting the game ]", 6000, updateMessage: true, updateMessageAtPosition: 1);
Announcer.Message("\t< Welcome to Battle Arena >", 2000, updateMessage: true, updateMessageAtPosition: 1);

Random decisionPicker = new();

var players = Players.List();
int totalPlayersInGame = players.Count;
int totalPlayersOutGame = 0;

int gameRound = 1;

// Display Battle Status
string labelTotalPlayersInGame = "Total Players Inside Arena: ";
string labelTotalPlayersOutGame = "Total Players Eliminated: ";
string labelRemainingPlayers = "Remaining Players: ";

Announcer.Message($"\n\t{labelTotalPlayersInGame}{totalPlayersInGame}", 500);
Announcer.Message($"\t{labelTotalPlayersOutGame}{totalPlayersOutGame}", 500);
Announcer.Message($"\t{labelRemainingPlayers}{players.Count}", 500);

Warrior playerOne = new(decisionPicker, players[decisionPicker.Next(players.Count)], 3);
players.Remove(playerOne.GetWarriorName());
Warrior playerTwo = new(decisionPicker, players[decisionPicker.Next(players.Count)], 3);
players.Remove(playerTwo.GetWarriorName());

// 1v1 Status place holder
Announcer.Message($"\n", 0);
Announcer.Message("", 0);

// Game round place holder
Announcer.Message("\n", 1000);

// Players turn place holder
Announcer.Message("\n", 0);
Announcer.Message("\n", 0);

// Game Over place holder
Announcer.Message("\n", 0);

// Winning player place holder
Announcer.Message("\n", 0);
Announcer.Message("", 0);

// Iliminated player place holder
Announcer.Message("\n", 0);
Announcer.Message("", 0);

while (players.Count >= 0)
{
    Announcer.Message($"\tRound {gameRound}", 5000, updateMessage: true, updateMessageAtPosition: 7);

    // Update Battle Status
    Announcer.Message($"\t{labelTotalPlayersOutGame}{totalPlayersOutGame}", 0, updateMessage: true, updateMessageAtPosition: 4);
    Announcer.Message($"\t{labelRemainingPlayers}{totalPlayersInGame}", 0, updateMessage: true, updateMessageAtPosition: 5);

    Announcer.Message(Announcer.RenderPlayerInfo(playerOne.GetWarriorName(), playerTwo.GetWarriorName()), 1000, updateMessage: true, updateMessageAtPosition: 9);
    Announcer.Message(Announcer.RenderPlayerHpInfo($"{playerOne.GetMaxHealth()} HP", $"{playerTwo.GetMaxHealth()} HP"), 1000, updateMessage: true, updateMessageAtPosition: 10);

    // Battle Area
    Arena arena = new(playerOne, playerTwo, decisionPicker);
    arena.Fight();


    // Cleanups

    // Clear "1v1" message status
    Announcer.Message(" ", 5000, updateMessage: true, updateMessageAtPosition: 9);
    Announcer.Message(" ", 0, updateMessage: true, updateMessageAtPosition: 10);

    // Clear battle message
    Announcer.Message(" ", 0, updateMessage: true, updateMessageAtPosition: 12);
    Announcer.Message(" ", 0, updateMessage: true, updateMessageAtPosition: 13);

    // Clear "Game Over" message
    Announcer.Message(" ", 0, updateMessage: true, updateMessageAtPosition: 15);

    // Clear Result Area
    Announcer.Message(" ", 0, updateMessage: true, updateMessageAtPosition: 17);
    Announcer.Message(" ", 0, updateMessage: true, updateMessageAtPosition: 18);

    Announcer.Message(" ", 0, updateMessage: true, updateMessageAtPosition: 20);
    Announcer.Message(" ", 0, updateMessage: true, updateMessageAtPosition: 21);

    totalPlayersInGame -= 1;
    totalPlayersOutGame += 1;

    if (players.Count == 0)
    {
        // Update Battle Status
        Announcer.Message($"\t{labelTotalPlayersOutGame}{totalPlayersOutGame}", 0, updateMessage: true, updateMessageAtPosition: 4);
        Announcer.Message($"\t{labelRemainingPlayers}{totalPlayersInGame}", 0, updateMessage: true, updateMessageAtPosition: 5);

        Announcer.Message($"\t{Announcer.GetChampion()} is the Champion!", 0, updateMessage: true, updateMessageAtPosition: 12, consoleColor: ConsoleColor.DarkGreen);

        break;
    }
    else
    {
        playerOne = playerOne.RestoreHP(Announcer.GetChampion());
        playerTwo = new(decisionPicker, players[decisionPicker.Next(players.Count)], 3);

        Announcer.Message($"\tNext player to fight: {playerTwo.GetWarriorName()}", 1000, updateMessage: true, updateMessageAtPosition: 7);

        players.Remove(playerTwo.GetWarriorName());

        gameRound += 1;
    }
}

Console.ReadLine();


