namespace BrainGames.Models.MenuState
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class Box : GameObject
    {
        public Box(Texture2D texture, Rectangle rectangle)
            : base(texture, rectangle)
        {
            this.Position = new Vector2(this.Rectangle.X, this.Rectangle.Y);
        }

        public Vector2 Position { get; set; }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.Rectangle, Color.White);
        }

        //public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        //{
        //    spriteBatch.Draw(this.Texture, this.Position, Color.White);
        //}
    }
}
