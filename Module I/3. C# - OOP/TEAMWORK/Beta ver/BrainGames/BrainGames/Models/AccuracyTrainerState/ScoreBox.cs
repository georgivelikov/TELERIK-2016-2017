namespace BrainGames.Models.AccuracyTrainerState
{
    using System;

    using global::BrainGames.Utilities.Constants;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System.Diagnostics;

    class ScoreBox : GameObject
    {
        private ShootingRange shootingRange;
        private SpriteFont font;
        private Stopwatch timer = new Stopwatch();

        public ScoreBox(Texture2D texture, Rectangle rectangle, ShootingRange shootingRange, SpriteFont font)
            : base(texture, rectangle)
        {
            this.shootingRange = shootingRange;
            this.font = font;
            this.timer.Start();
        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.Rectangle, Color.White);

            spriteBatch.DrawString(
                this.font,
                string.Format("Score: {0}", this.shootingRange.Score),
                new Vector2(AccuracyTrainerStateConstants.ScoreBoxScoreStartX, AccuracyTrainerStateConstants.ScoreBoxScoreStartY),
                Color.White,
                0,
                new Vector2(0, 0),
                new Vector2(MemoryMatrixConstants.FontScale, MemoryMatrixConstants.FontScale),
                SpriteEffects.None,
                0f);

            spriteBatch.DrawString(
                this.font,
                string.Format("Time: {0:mm\\:ss}", timer.Elapsed),
                new Vector2(AccuracyTrainerStateConstants.ScoreBoxTimeStartX, AccuracyTrainerStateConstants.ScoreBoxTimeStartY),
                Color.White,
                0,
                new Vector2(0, 0),
                new Vector2(MemoryMatrixConstants.FontScale, MemoryMatrixConstants.FontScale),
                SpriteEffects.None,
                0f);
            spriteBatch.DrawString(
                this.font,
                string.Format("Stage: {0} / {1}", this.shootingRange.Stage, AccuracyTrainerStateConstants.TotalStages),
                new Vector2(AccuracyTrainerStateConstants.ScoreBoxStageStartX, AccuracyTrainerStateConstants.ScoreBoxStageStartY),
                Color.White,
                0,
                new Vector2(0, 0),
                new Vector2(MemoryMatrixConstants.FontScale, MemoryMatrixConstants.FontScale),
                SpriteEffects.None,
                0f);
        }
    }
}
