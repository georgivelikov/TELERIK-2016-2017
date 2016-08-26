namespace BrainGames.Models.MemoryMatrixState
{
    using System;

    using global::BrainGames.Utilities.Constants;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class UpperMenu : GameObject
    {
        private GameBoard gameBoard;
        private SpriteFont font;

        public UpperMenu(Texture2D texture, Rectangle rectangle, GameBoard gameBoard, SpriteFont font)
            : base(texture, rectangle)
        {
            this.gameBoard = gameBoard;
            this.font = font;
        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.Rectangle, Color.White);
            spriteBatch.DrawString(
                this.font,
                string.Format("Level: {0}", this.gameBoard.LevelNumber),
                new Vector2(MemoryMatrixConstants.UpperMenuLevelStartX, MemoryMatrixConstants.UpperMenuLevelStartY),
                Color.White,
                0,
                new Vector2(0, 0),
                new Vector2(MemoryMatrixConstants.FontScale, MemoryMatrixConstants.FontScale), 
                SpriteEffects.None, 
                0f);

            spriteBatch.DrawString(
                this.font,
                string.Format("Score: {0}", this.gameBoard.BoardScore),
                new Vector2(MemoryMatrixConstants.UpperMenuScoreStartX, MemoryMatrixConstants.UpperMenuScoreStartY),
                Color.White,
                0,
                new Vector2(0, 0),
                new Vector2(MemoryMatrixConstants.FontScale, MemoryMatrixConstants.FontScale),
                SpriteEffects.None,
                0f);

            spriteBatch.DrawString(
                this.font,
                string.Format("Blocks left: {0}", this.gameBoard.BlocksLeft),
                new Vector2(MemoryMatrixConstants.UpperMenuBlocksStartX, MemoryMatrixConstants.UpperMenuBlocksStartY),
                Color.White,
                0,
                new Vector2(0, 0),
                new Vector2(MemoryMatrixConstants.FontScale, MemoryMatrixConstants.FontScale),
                SpriteEffects.None,
                0f);
        }
    }
}
