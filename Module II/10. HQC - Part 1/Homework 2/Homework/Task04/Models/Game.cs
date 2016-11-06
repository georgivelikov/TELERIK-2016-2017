using System;
using System.Collections.Generic;
using System.Linq;

namespace Minesweepers.Models
{
    public class Game
    {
        private const int BoardRows = 5;
        private const int BoardCols = 10;
        private const int NumberOfMinesOnBoard = 15;
        private const int MaxTurns = 35;
        private const int MaxNumberOfTopPlayers = 6;

        private static Random random = new Random();

        private char[,] board;
        private char[,] bombs;
        private bool gameStarted;
        private int turnsCounter;
        private bool gameOverWithSuccess;
        private List<Player> topPlayers;

        public Game()
        {
            this.board = this.CreateBoard();
            this.bombs = this.PlaceBombs();
            this.turnsCounter = 0;
            this.gameStarted = false;
            this.gameOverWithSuccess = false;
            this.topPlayers = new List<Player>();
        }

        public bool GameOverWithSuccess
        {
            get { return this.gameOverWithSuccess; }
            set { this.gameOverWithSuccess = value; }
        }

        public bool GameStarted
        {
            get { return this.gameStarted; }
            set { this.gameStarted = value; }
        }

        public char[,] Board
        {
            get { return this.board; }
        }

        public char[,] Bombs
        {
            get { return this.bombs; }
        }

        public void WriteGameBoard(char[,] board)
        {
            int rowLength = board.GetLength(0);
            int colLength = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < rowLength; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(String.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        public void HandleCommand(string line)
        {
            string command = String.Empty;
            string[] args = line.Split();
            if (args.Length > 1) // 0 9; 1 3 - валидни командa за позиция на борда
            {
                command = "turn";
            }
            else
            {
                command = line;
            }

            switch (command)
            {
                case "turn":
                    this.HandleTurnCommand(args);
                    this.WriteGameBoard(this.board);
                    break;
                case "top":
                    this.PrintTopRankings();
                    break;
                case "restart":
                    this.RestartGame();
                    break;
                case "exit":
                    this.HandleExitCommand();
                    break;
                default:
                    Console.WriteLine("Invalid command!");
                    break;
            }
            if (this.GameOverWithSuccess)
            {
                Console.WriteLine("\nWell done! You have opened all the boxes without loosing a drop of blood!");
                this.WriteGameBoard(this.bombs);
                Console.WriteLine("Please enter name: ");
                string name = Console.ReadLine();
                Player player = new Player(name, this.turnsCounter);
                topPlayers.Add(player);
                this.PrintTopRankings();
                this.RestartGame();
            }
        }

        private char[,] CreateBoard()
        {
            char[,] board = new char[BoardRows, BoardCols];
            for (int i = 0; i < BoardRows; i++)
            {
                for (int j = 0; j < BoardCols; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private char[,] PlaceBombs()
        {
            char[,] bombs = new char[BoardRows, BoardCols];

            for (int i = 0; i < BoardRows; i++)
            {
                for (int j = 0; j < BoardCols; j++)
                {
                    bombs[i, j] = '-';
                }
            }

            List<int> minesList = new List<int>();
            while (minesList.Count < NumberOfMinesOnBoard)
            {
                int minePosition = random.Next(0, BoardRows * BoardCols);

                if (!minesList.Contains(minePosition))
                {
                    minesList.Add(minePosition);
                }
            }

            foreach (int position in minesList)
            {
                int row = position / BoardCols;
                int col = position % BoardCols;

                if (col == 0 && position != 0)
                {
                    row--;
                    col = BoardCols;
                }
                else
                {
                    col++;
                }

                bombs[row, col - 1] = '*';
            }

            return bombs;
        }

        private void HandleTurnCommand(string[] args)
        {
            int row = int.Parse(args[0]);
            int col = int.Parse(args[1]);

            if (row < 0 || row >= this.board.GetLength(0))
            {
                Console.WriteLine("Invalid row input!");
                return;
            }
            if (col < 0 || col >= this.board.GetLength(1))
            {
                Console.WriteLine("Invalid column input!");
                return;
            }

            if (this.bombs[row, col] != '*')
            {
                char numberOfBombsAroud = this.GetHowManyBombsAreAround(row, col);
                this.board[row, col] = numberOfBombsAroud;
                this.bombs[row, col] = numberOfBombsAroud;
                this.turnsCounter++;

                if (this.turnsCounter == MaxTurns)
                {
                    this.GameOverWithSuccess = true;
                }
            }
            else
            {
                this.HandleMineExplosion();
            }

        }

        private void HandleExitCommand()
        {
            Console.WriteLine("Made in Bulgaria");
        }

        private void HandleMineExplosion()
        {
            this.WriteGameBoard(this.bombs);
            Console.Write("\nHrrrrrr! You die like a hero with {0} points. " + "Enter your nickname: ", this.turnsCounter);
            string nickname = Console.ReadLine();
            Player player = new Player(nickname, this.turnsCounter);

            if (topPlayers.Count < MaxNumberOfTopPlayers)
            {
                topPlayers.Add(player);
            }
            else
            {
                for (int i = 0; i < topPlayers.Count; i++)
                {
                    if (topPlayers[i].Points < player.Points)
                    {
                        topPlayers.Insert(i, player);
                        topPlayers.RemoveAt(topPlayers.Count - 1);
                        break;
                    }
                }
            }

            topPlayers.Sort((Player player1, Player player2) => player2.Name.CompareTo(player1.Name));
            topPlayers.Sort((Player player1, Player player2) => player.Points.CompareTo(player1.Points));

            this.PrintTopRankings();
            this.RestartGame();
        }

        private char GetHowManyBombsAreAround(int row, int col)
        {
            int countOfBombs = 0;

            int maxRow = this.bombs.GetLength(0);
            int maxCol = this.bombs.GetLength(1);

            if (row - 1 >= 0)
            {
                if (this.bombs[row - 1, col] == '*')
                {
                    countOfBombs++;
                }
            }

            if (row + 1 < maxRow)
            {
                if (this.bombs[row + 1, col] == '*')
                {
                    countOfBombs++;
                }
            }

            if (col - 1 >= 0)
            {
                if (this.bombs[row, col - 1] == '*')
                {
                    countOfBombs++;
                }
            }

            if (col + 1 < maxCol)
            {
                if (this.bombs[row, col + 1] == '*')
                {
                    countOfBombs++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (this.bombs[row - 1, col - 1] == '*')
                {
                    countOfBombs++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < maxCol))
            {
                if (this.bombs[row - 1, col + 1] == '*')
                {
                    countOfBombs++;
                }
            }

            if ((row + 1 < maxRow) && (col - 1 >= 0))
            {
                if (this.bombs[row + 1, col - 1] == '*')
                {
                    countOfBombs++;
                }
            }

            if ((row + 1 < maxRow) && (col + 1 < maxCol))
            {
                if (this.bombs[row + 1, col + 1] == '*')
                {
                    countOfBombs++;
                }
            }

            return Char.Parse(countOfBombs.ToString());
        }

        private void PrintTopRankings()
        {
            Console.WriteLine("\nRankings:");
            if (topPlayers.Count > 0)
            {
                this.topPlayers.OrderByDescending(x => x.Points);
                for (int i = 0; i < topPlayers.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} points", i + 1, topPlayers[i].Name, topPlayers[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No data yet!\n");
            }
        }

        private void RestartGame()
        {
            this.board = this.CreateBoard();
            this.bombs = this.PlaceBombs();
            this.turnsCounter = 0;
        }

    }
}

