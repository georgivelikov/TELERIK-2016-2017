namespace BrainGames.Models.MemoryMatrixState
{
    using global::BrainGames.Utilities.CustomExceptions;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using Utilities.Constants;

    public class GameBoard : GameObject
    {
        private Block[,] board;
        private bool isBoardHidden;
        private int boardScore;
        private int blocksLeft;
        private int levelNumber;
        private int difficultyBonus;

        public GameBoard(Texture2D texture, Rectangle rectangle, int boardScore, int levelNumber, int blocksLeft, int difficltyBonus)
            : base(texture, rectangle)
        {
            this.BoardScore = boardScore;
            this.LevelNumber = levelNumber;
            this.BlocksLeft = blocksLeft;
            this.difficultyBonus = difficltyBonus;
        }

        public Block[,] Board
        {
            get
            {
                return this.board;
            }

            set
            {
                this.board = value;
            }
        }

        public bool IsBoardHidden
        {
            get
            {
                return this.isBoardHidden;
            }

            set
            {
                if (this.isBoardHidden)
                {
                    throw new HiddenBoardException("Board can be hidden only once at the beggining of the level!");
                }

                this.isBoardHidden = true;
            }

        }

        public int BoardScore
        {
            get
            {
                return this.boardScore;
            }

            set
            {
                this.boardScore = value;
            }
        }

        public int BlocksLeft
        {
            get
            {
                return this.blocksLeft;
            }

            set
            {
                this.blocksLeft = value;
            }
        }

        public int LevelNumber
        {
            get
            {
                return this.levelNumber;
            }

            set
            {
                this.levelNumber = value;
            }
        }

        public override void Update(GameTime gameTime)
        {
            for (int row = 0; row < MemoryMatrixConstants.Size; row++)
            {
                for (int col = 0; col < MemoryMatrixConstants.Size; col++)
                {
                    this.board[row, col].Update(gameTime);
                    if (!this.board[row, col].IsCalculatedToScore)
                    {
                        if (this.board[row, col].Code == MemoryMatrixConstants.TurnedCorrectCode)
                        {
                            this.BoardScore += MemoryMatrixConstants.BonusForCorrect * this.difficultyBonus;
                            this.BlocksLeft--;
                            this.board[row, col].IsCalculatedToScore = true;
                        }

                        if (this.board[row, col].Code == MemoryMatrixConstants.TurnedWrongCode)
                        {
                            this.BoardScore -= MemoryMatrixConstants.PenaltyForWrong * this.difficultyBonus;
                            this.board[row, col].IsCalculatedToScore = true;
                        }
                    }
                }
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.Rectangle, Color.White);

            for (int row = 0; row < MemoryMatrixConstants.Size; row++)
            {
                for (int col = 0; col < MemoryMatrixConstants.Size; col++)
                {
                    this.board[row, col].Draw(gameTime, spriteBatch);
                }
            }
        }
    }
}
