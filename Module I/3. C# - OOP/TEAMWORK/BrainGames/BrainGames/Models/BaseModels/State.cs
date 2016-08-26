namespace BrainGames.Models
{
    using System.Collections.Generic;

    using global::BrainGames.Utilities.Textures;

    using Interfaces;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class State : IState
    {
        private Background background;
        private GameStateManager gsm;
        private List<GameObject> listOfObjects = new List<GameObject>();
        private Textures textures;

        public State(Background background, GameStateManager gsm, Textures textures)
        {
            this.Background = background;
            this.StateManager = gsm;
            this.textures = textures;
            this.ListOfObjects.Add(this.Background);
        }

        public Textures GameTextures
        {
            get
            {
                return this.textures;
            }
        }

        public Background Background
        {
            get
            {
                return this.background;
            }

            private set
            {
                this.background = value;
            }
        }

        public GameStateManager StateManager
        {
            get
            {
                return this.gsm;
            }

            private set
            {
                this.gsm = value;
            }
        }

        public List<GameObject> ListOfObjects
        {
            get
            {
                return this.listOfObjects;
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (var gameObject in this.ListOfObjects)
            {
                gameObject.Update(gameTime);
            }
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (var gameObject in this.ListOfObjects)
            {
                gameObject.Draw(gameTime, spriteBatch);
            }
        }
    }
}
