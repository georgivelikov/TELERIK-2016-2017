namespace BrainGames.Models
{
    using Interfaces;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class GameObject : IGameObject
    {
        private Texture2D texture;
        private Rectangle rectangle;

        public GameObject(Texture2D texture, Rectangle rectangle)
        {
            this.Texture = texture;
            this.Rectangle = rectangle;
        }

        public Texture2D Texture
        {
            get
            {
                return this.texture;
            }

            set
            {
                this.texture = value;
            }
        }

        public Rectangle Rectangle
        {
            get
            {
                return this.rectangle;
            }

            set
            {
                this.rectangle = value;
            }
        }

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
