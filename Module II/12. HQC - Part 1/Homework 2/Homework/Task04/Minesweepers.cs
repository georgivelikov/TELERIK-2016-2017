using System;
using Minesweepers.Models;

namespace Minesweepers
{
    public class Minesweepers
    {
        private static void Main()
        {
            Game game = new Game();

            string command = string.Empty;

            if (!game.GameStarted)
            {
                Console.WriteLine("Lets playe \"Minesweepers\". Try your luck and find a place without mine!");
                Console.WriteLine("Type \"Top\" for Rankings");
                Console.WriteLine("Type \"Restart\" to restart the game");
                Console.WriteLine("Type \"Exit\" to exit the game");

                game.WriteGameBoard(game.Board);

                game.GameStarted = true;
            }
            while (command != "exit")
            {
                Console.Write("Choose row and column or enter command: ");
                command = Console.ReadLine().Trim();
                game.HandleCommand(command);
            }
        }

    }
}