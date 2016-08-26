namespace BrainGames.Models
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using Utilities.Constants;

    public class Background : GameObject
    {
        public Background(Texture2D texture)
            : base(texture, new Rectangle(0, 0, GlobalConstants.WindowWidth, GlobalConstants.WindowHeight))
        {
        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.Rectangle, Color.White);
        }
    }
}
