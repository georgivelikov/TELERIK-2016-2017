namespace BrainGames.Models.MemoryMatrixState
{
    using System.IO;
    using System.Threading;

    using global::BrainGames.Models.BaseModels.Boxes;

    using Microsoft.Xna.Framework;

    using Models.AccuracyTrainerState;

    using Utilities.Constants;
    using Utilities.Textures;

    public class AccuracyTrainerState : State
    {
        private ClickableBox quit;
        private ScoreBox scoreBox;
        private ShootingRange shootingRange;

        public AccuracyTrainerState(Background background, GameStateManager gsm, Textures textures)
            : base(background, gsm, textures)
        {
            this.InitializeObjects();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (this.shootingRange.Stage == AccuracyTrainerStateConstants.TotalStages)
            {
                this.QuitGame();
            }

            if (this.quit.CheckForClick())
            {
                this.QuitGame();
            }
        }

        private void InitializeObjects()
        {
            this.InitializeQuitButton();
            this.InitializeShootingRange();
            this.InitializeScoreBox();   
        }

        private void InitializeShootingRange()
        {
            this.shootingRange = new ShootingRange(
            this.GameTextures.GetTexture("MemoryMatrixGameBoard"),
            new Rectangle(
                MemoryMatrixConstants.GameBoardStartingX,
                MemoryMatrixConstants.GameBoardStartingY,
                MemoryMatrixConstants.GameBoardStartingWidth,
                MemoryMatrixConstants.GameBoardStartingHeight),
            this.StateManager.Difficulty,
            this.StateManager.Game.GameTextures);
            this.ListOfObjects.Add(this.shootingRange);
        }

        private void InitializeScoreBox()
        {
            var texture = this.GameTextures.GetTexture("MemoryMatrixUpperMenu");
            var rectangle = new Rectangle(
                MemoryMatrixConstants.UpperMenuStartingX,
                MemoryMatrixConstants.UpperMenuStartingY,
                MemoryMatrixConstants.UpperMenuStartingWidth,
                MemoryMatrixConstants.UpperMenuStartingHeight);

            this.scoreBox = new ScoreBox(texture, rectangle, this.shootingRange, this.StateManager.Game.SpriteFont);
            this.ListOfObjects.Add(this.scoreBox);
        }

        private void InitializeQuitButton()
        {
            this.quit = new ClickableBox(
                this.GameTextures.GetTexture("Quit"),
                new Rectangle(
                    MemoryMatrixConstants.QuitStartingX,
                    MemoryMatrixConstants.QuitStartingY,
                    MemoryMatrixConstants.QuitStartingWidth,
                    MemoryMatrixConstants.QuitStartingHeight));
            this.ListOfObjects.Add(this.quit);
        }

        private void QuitGame()
        {
            this.SaveResults();
            Thread.Sleep(MemoryMatrixConstants.IntervalBeforeQuit);
            this.StateManager.States.Pop();
        }

        private void SaveResults()
        {
            using (StreamWriter writer = new StreamWriter(GlobalConstants.AccTrainerHighScorePath, true))
            {
                writer.WriteLine(this.shootingRange.Score);
            }
        }
    }
}