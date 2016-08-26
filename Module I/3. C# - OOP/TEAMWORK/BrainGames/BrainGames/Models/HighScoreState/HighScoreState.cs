namespace BrainGames.Models.MemoryMatrixState
{
    using System.Threading;

    using global::BrainGames.Models.BaseModels.Boxes;

    using Microsoft.Xna.Framework;

    using Models.AccuracyTrainerState;

    using Utilities.Constants;
    using Utilities.Textures;

    public class HighScoreState : State
    {
        private ClickableBox quit;
        private ScoreList scoreList;

        public HighScoreState(Background background, GameStateManager gsm, Textures textures)
            : base(background, gsm, textures)
        {
            this.InitializeObjects();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (this.quit.CheckForClick())
            {
                this.QuitGame();
            }
        }

        private void InitializeObjects()
        {
            this.InitializeBackButton();
            this.InitializeScoreList();
        }

        private void InitializeScoreList()
        {
            this.scoreList = new ScoreList(
            this.GameTextures.GetTexture("HighScoreBackground"),
            new Rectangle(
                MemoryMatrixConstants.GameBoardStartingX,
                MemoryMatrixConstants.GameBoardStartingY,
                MemoryMatrixConstants.GameBoardStartingWidth,
                MemoryMatrixConstants.GameBoardStartingHeight),
            this.StateManager.Game.SpriteFont);
            this.ListOfObjects.Add(this.scoreList);
        }

        private void InitializeBackButton()
        {
            this.quit = new ClickableBox(
                this.GameTextures.GetTexture("BackButton"),
                new Rectangle(
                    HighScoreStateConstants.BackStartingX,
                    HighScoreStateConstants.BackStartingY,
                    HighScoreStateConstants.BackStartingWidth,
                    HighScoreStateConstants.BackStartingHeight));
            this.ListOfObjects.Add(this.quit);
        }

        private void QuitGame()
        {
            Thread.Sleep(MemoryMatrixConstants.IntervalBeforeQuit);
            this.StateManager.States.Pop();
        }
    }
}
