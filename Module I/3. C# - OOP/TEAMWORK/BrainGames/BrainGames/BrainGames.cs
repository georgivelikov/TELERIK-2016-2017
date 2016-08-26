namespace BrainGames
{
    using global::BrainGames.Models;
    using global::BrainGames.Models.BaseModels.Boxes;
    using global::BrainGames.Models.MenuState;
    using global::BrainGames.Utilities.Textures;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    using Utilities.Constants;

    public class BrainGames : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private GameStateManager stateManager;
        private SpriteFont spriteFont;
        private Textures gameTextures;

        public BrainGames()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.gameTextures = Textures.GetInstance();
            this.Content.RootDirectory = "Content";
            this.graphics.PreferredBackBufferWidth = GlobalConstants.WindowWidth;
            this.graphics.PreferredBackBufferHeight = GlobalConstants.WindowHeight;
            this.IsMouseVisible = true;
        }

        public SpriteFont SpriteFont
        {
            get
            {
                return this.spriteFont;
            }
        }

        public Textures GameTextures
        {
            get
            {
                return this.gameTextures;
            }
        }

        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
            this.GameTextures.InitiateTextures(this);
            this.spriteFont = this.Content.Load<SpriteFont>("Fonts\\ArialFont");
            this.stateManager = new GameStateManager(this);
            Background startingBackground = new Background(this.GameTextures.GetTexture("MenuBackground")); // starting state is Menu State
            MenuState menuState = new MenuState(startingBackground, this.stateManager, this.GameTextures);
            this.stateManager.States.Push(menuState);
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            this.stateManager.States.Peek().Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.Black);

            this.spriteBatch.Begin();
            this.stateManager.States.Peek().Draw(gameTime, this.spriteBatch);
            this.spriteBatch.End();
        }
    }
}
