namespace BrainGames.Models.AccuracyTrainerState
{
    using System.IO;
    using System.Linq;

    using global::BrainGames.Utilities.Constants;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class ScoreList : GameObject
    {
        private SpriteFont font;
        private string[] accTrainerScores;
        private string[] memoryMatrixScores;
        private string[] simonSaysScores;
        private string[] eagleEyeScores;

        public ScoreList(Texture2D texture, Rectangle rectangle, SpriteFont font)
            : base(texture, rectangle)
        {
            this.font = font;
            this.InitializeScores();
        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.Rectangle, Color.White);
            this.DrawAccTrainerScores(spriteBatch);
            this.DrawMemoryMatrixScores(spriteBatch);
            this.DrawSimonSaysScores(spriteBatch);
        }

        private void DrawAccTrainerScores(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(
                this.font,
                HighScoreStateConstants.AccTrainerName,
                new Vector2(HighScoreStateConstants.AccTrainerXpos, HighScoreStateConstants.AccTrainerYpos),
                new Color(HighScoreStateConstants.CustomColorRed, HighScoreStateConstants.CustomColorGreen, HighScoreStateConstants.CustomColorBlue),
                0,
                new Vector2(0, 0),
                new Vector2(HighScoreStateConstants.FontScale, HighScoreStateConstants.FontScale),
                SpriteEffects.None,
                0f);
            spriteBatch.DrawString(
                this.font,
                HighScoreStateConstants.MemoryMatrixName,
                new Vector2(HighScoreStateConstants.MemoryMatrixXpos, HighScoreStateConstants.MemoryMatrixYpos),
                new Color(HighScoreStateConstants.CustomColorRed, HighScoreStateConstants.CustomColorGreen, HighScoreStateConstants.CustomColorBlue),
                0,
                new Vector2(0, 0),
                new Vector2(HighScoreStateConstants.FontScale, HighScoreStateConstants.FontScale),
                SpriteEffects.None,
                0f);

            int accTrainerLineCount;
            if (this.accTrainerScores.Length < HighScoreStateConstants.MaxDisplayRows)
            {
                accTrainerLineCount = this.accTrainerScores.Length;
            }
            else
            {
                accTrainerLineCount = HighScoreStateConstants.MaxDisplayRows;
            }

            for (int i = 0; i < accTrainerLineCount; i++)
            {
                this.DrawLine(this.accTrainerScores[i], spriteBatch, HighScoreStateConstants.AccTrainerScoresXpos, HighScoreStateConstants.AccTrainerScoresStartingYpos + (i * HighScoreStateConstants.AccTrainerScoresYinterval));
            }
        }

        private void DrawMemoryMatrixScores(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(
                this.font,
                HighScoreStateConstants.MemoryMatrixName,
                new Vector2(HighScoreStateConstants.MemoryMatrixXpos, HighScoreStateConstants.MemoryMatrixYpos),
                new Color(HighScoreStateConstants.CustomColorRed, HighScoreStateConstants.CustomColorGreen, HighScoreStateConstants.CustomColorBlue),
                0,
                new Vector2(0, 0),
                new Vector2(HighScoreStateConstants.FontScale, HighScoreStateConstants.FontScale),
                SpriteEffects.None,
                0f);

            int memoryMatrixLineCount;
            if (this.memoryMatrixScores.Length < HighScoreStateConstants.MaxDisplayRows)
            {
                memoryMatrixLineCount = this.memoryMatrixScores.Length;
            }
            else
            {
                memoryMatrixLineCount = HighScoreStateConstants.MaxDisplayRows;
            }

            for (int i = 0; i < memoryMatrixLineCount; i++)
            {
                this.DrawLine(this.memoryMatrixScores[i], spriteBatch, HighScoreStateConstants.MemoryMatrixScoresXpos, HighScoreStateConstants.MemoryMatrixScoresStartingYpos + (i * HighScoreStateConstants.MemoryMatrixScoresYinterval));
            }
        }

        private void DrawSimonSaysScores(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(
                this.font,
                HighScoreStateConstants.SimonSaysName,
                new Vector2(HighScoreStateConstants.SimonSaysXpos, HighScoreStateConstants.SimonSaysYpos),
                new Color(HighScoreStateConstants.CustomColorRed, HighScoreStateConstants.CustomColorGreen, HighScoreStateConstants.CustomColorBlue),
                0,
                new Vector2(0, 0),
                new Vector2(HighScoreStateConstants.FontScale, HighScoreStateConstants.FontScale),
                SpriteEffects.None,
                0f);
            spriteBatch.DrawString(
                this.font,
                HighScoreStateConstants.SimonSaysName,
                new Vector2(HighScoreStateConstants.SimonSaysXpos, HighScoreStateConstants.SimonSaysYpos),
                new Color(HighScoreStateConstants.CustomColorRed, HighScoreStateConstants.CustomColorGreen, HighScoreStateConstants.CustomColorBlue),
                0,
                new Vector2(0, 0),
                new Vector2(HighScoreStateConstants.FontScale, HighScoreStateConstants.FontScale),
                SpriteEffects.None,
                0f);
            
            int simonSaysLineCount;
            if (this.simonSaysScores.Length < HighScoreStateConstants.MaxDisplayRows)
            {
                simonSaysLineCount = this.simonSaysScores.Length;
            }
            else
            {
                simonSaysLineCount = HighScoreStateConstants.MaxDisplayRows;
            }

            for (int i = 0; i < simonSaysLineCount; i++)
            {
                this.DrawLine(this.simonSaysScores[i], spriteBatch, HighScoreStateConstants.SimonSaysScoresXpos, HighScoreStateConstants.SimonSaysScoresStartingYpos + (i * HighScoreStateConstants.SimonSaysScoresYinterval));
            }
        }

        private void InitializeScores()
        {
            this.accTrainerScores = File.ReadAllLines(GlobalConstants.AccTrainerHighScorePath);
            this.accTrainerScores = this.accTrainerScores.OrderByDescending(x => int.Parse(x)).ToArray();

            this.memoryMatrixScores = File.ReadAllLines(GlobalConstants.MemoryMatrixHighScorePath);
            this.memoryMatrixScores = this.memoryMatrixScores.OrderByDescending(x => int.Parse(x)).ToArray();

            this.simonSaysScores = File.ReadAllLines(GlobalConstants.SimonSaysHighScorePath);
            this.simonSaysScores = this.simonSaysScores.OrderByDescending(x => int.Parse(x)).ToArray();
        }

        private void DrawLine(string line, SpriteBatch spriteBatch, int xPos, int yPos)
        {
            spriteBatch.DrawString(
                this.font,
                string.Format("Score: {0}", line),
                new Vector2(xPos, yPos),
                Color.White,
                0,
                new Vector2(0, 0),
                new Vector2(HighScoreStateConstants.FontScale, HighScoreStateConstants.FontScale),
                SpriteEffects.None,
                0f);
        }
    }
}
