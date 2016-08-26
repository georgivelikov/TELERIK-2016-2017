namespace BrainGames.Models.SimonSaysState
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Threading;

    using BaseModels.Boxes;

    using global::BrainGames.Utilities.Constants;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    using Utilities.Textures;

    public class SimonSaysState : State
    {
        private ClickableBox greenButton;
        private ClickableBox redButton;
        private ClickableBox blueButton;
        private ClickableBox yellowButton;

        private ClickableBox quitButton;

        private float timer = 2f;
        private float elapsedTime;
        private bool allowedToContinue = false;

        private int onInList = 0;
        private int counter = 1;
        private List<int> pattern = new List<int>();
        private Random rand = new Random();
        private bool playingBack = false;
        private int maxScore = 0;
        private int bestScore = 0;
        private bool greenClicked = false;
        private bool blueClicked = false;
        private bool redClicked = false;
        private bool yellowClicked = false;
        private string active = string.Empty;
        private List<SoundEffect> soundEffects = new List<SoundEffect>();

        private MouseState oldMouseState;
        private MouseState currentMouseState;

        public SimonSaysState(Background background, GameStateManager gsm, Textures textures)
            : base(background, gsm, textures)
        {
            this.InitializeButtons();
            this.InitializeSoundEffects();
        }

        public override void Update(GameTime gameTime)
        {
            this.SetBufferTimer(gameTime);
            if (!this.allowedToContinue)
            {
                return;
            }

            this.oldMouseState = this.currentMouseState;
            MouseState mouseState = Mouse.GetState();
            this.currentMouseState = mouseState;

            if (mouseState.LeftButton == ButtonState.Pressed && this.oldMouseState.LeftButton == ButtonState.Released && !this.playingBack)
            {
                // GREEN BUTTON PRESSED
                if (this.greenButton.CheckForClick())
                {
                    this.TestCorrect(0);
                    this.ClickButtonAnimation();
                    this.greenClicked = true;
                }
                //RED BUTTON PRESSED
                else if (this.redButton.CheckForClick() && !this.playingBack)
                {
                    this.TestCorrect(1);
                    this.ClickButtonAnimation();
                    this.redClicked = true;
                }
                //BLUE BUTTON PRESSED
                else if (this.blueButton.CheckForClick() && !this.playingBack)
                {
                    this.TestCorrect(2);
                    this.ClickButtonAnimation();
                    this.blueClicked = true;
                }
                //YELLOW BUTTON PRESSED
                else if (this.yellowButton.CheckForClick() && !this.playingBack)
                {
                    this.TestCorrect(3);
                    this.ClickButtonAnimation();
                    this.yellowClicked = true;
                }
            }

            if (this.quitButton.CheckForClick())
            {
                this.QuitGame();
            }

            if (this.onInList < this.counter)
            {
                this.pattern.Add(this.rand.Next(0, 4));
                new Thread(this.Playback).Start();
                this.counter--;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
            spriteBatch.DrawString(this.StateManager.Game.SpriteFont, "High Score " + this.bestScore, new Vector2(620, 100), Color.White);
            spriteBatch.DrawString(this.StateManager.Game.SpriteFont, "Score " + this.maxScore, new Vector2(620, 200), Color.White);
            spriteBatch.DrawString(this.StateManager.Game.SpriteFont, this.active, new Vector2(620, 300), Color.White);
            
        }

        private void InitializeButtons()
        {
            this.greenButton = new ClickableBox(this.GameTextures.GetTexture("GreenButton"), new Rectangle(5, 5, 258, 258));
            this.redButton = new ClickableBox(this.GameTextures.GetTexture("RedButton"), new Rectangle(5, 330, 258, 258));
            this.blueButton = new ClickableBox(this.GameTextures.GetTexture("BlueButton"), new Rectangle(330, 5, 258, 258));
            this.yellowButton = new ClickableBox(this.GameTextures.GetTexture("YellowButton"), new Rectangle(330, 330, 258, 258));
            this.ListOfObjects.Add(this.greenButton);
            this.ListOfObjects.Add(this.redButton);
            this.ListOfObjects.Add(this.blueButton);
            this.ListOfObjects.Add(this.yellowButton);

            this.quitButton = new ClickableBox(this.GameTextures.GetTexture("Quit"), new Rectangle(600, 600, 160, 41));
            this.ListOfObjects.Add(this.quitButton);

        }

        private void InitializeSoundEffects()
        {
            this.soundEffects.Add(this.StateManager.Game.Content.Load<SoundEffect>("SoundEffects/SimonSays/greenButtonSound"));
            this.soundEffects.Add(this.StateManager.Game.Content.Load<SoundEffect>("SoundEffects/SimonSays/blueButtonSound"));
            this.soundEffects.Add(this.StateManager.Game.Content.Load<SoundEffect>("SoundEffects/SimonSays/redButtonSound"));
            this.soundEffects.Add(this.StateManager.Game.Content.Load<SoundEffect>("SoundEffects/SimonSays/yellowButtonSound"));
        }

        private void ClickButtonAnimation()
        {
            new Thread(PlaybackAnimation).Start();
        }

        private void TestCorrect(int color)
        {
            if (this.playingBack)
            {
                return;
            }

            if (this.pattern[this.onInList] == color)
            {
                this.onInList++;
            }
            else
            {
                this.onInList = 0;
                this.maxScore = 0;
                this.pattern = new List<int>();
                new Thread(this.Playback).Start();
            }

            // Add new random
            if (this.onInList >= this.pattern.Count)
            {
                this.pattern.Add(this.rand.Next(0, 4));
                this.onInList = 0;
                this.maxScore++;
                if (this.bestScore < this.maxScore)
                {
                    this.bestScore = this.maxScore;
                }

                Debug.WriteLine(this.maxScore);
                new Thread(this.Playback).Start();
            }
        }

        private void Playback()
        {
            this.playingBack = true;
            if (this.maxScore == 0)
            {
                Thread.Sleep(600);
            }

            foreach (int color in this.pattern)
            {
                this.active = "SIMON";
                Thread.Sleep(600);
                switch (color)
                {
                    case 0:
                        this.greenButton.Rectangle = new Rectangle(this.greenButton.Rectangle.X, this.greenButton.Rectangle.Y + 50, this.greenButton.Rectangle.Width, this.greenButton.Rectangle.Height);
                        Thread.Sleep(200);
                        this.greenButton.Rectangle = new Rectangle(this.greenButton.Rectangle.X, this.greenButton.Rectangle.Y - 50, this.greenButton.Rectangle.Width, this.greenButton.Rectangle.Height);
                        this.soundEffects[0].Play();
                        break;
                    case 1:
                        this.redButton.Rectangle = new Rectangle(this.redButton.Rectangle.X, this.redButton.Rectangle.Y + 50, this.redButton.Rectangle.Width, this.redButton.Rectangle.Height);
                        Thread.Sleep(200);
                        this.redButton.Rectangle = new Rectangle(this.redButton.Rectangle.X, this.redButton.Rectangle.Y - 50, this.redButton.Rectangle.Width, this.redButton.Rectangle.Height);
                        this.soundEffects[1].Play();
                        break;
                    case 2:
                        this.blueButton.Rectangle = new Rectangle(this.blueButton.Rectangle.X, this.blueButton.Rectangle.Y + 50, this.blueButton.Rectangle.Width, this.blueButton.Rectangle.Height);
                        Thread.Sleep(200);
                        this.blueButton.Rectangle = new Rectangle(this.blueButton.Rectangle.X, this.blueButton.Rectangle.Y - 50, this.blueButton.Rectangle.Width, this.blueButton.Rectangle.Height);
                        this.soundEffects[2].Play();
                        break;
                    case 3:
                        this.yellowButton.Rectangle = new Rectangle(this.yellowButton.Rectangle.X, this.yellowButton.Rectangle.Y + 50, this.yellowButton.Rectangle.Width, this.yellowButton.Rectangle.Height);
                        Thread.Sleep(200);
                        this.yellowButton.Rectangle = new Rectangle(this.yellowButton.Rectangle.X, this.yellowButton.Rectangle.Y - 50, this.yellowButton.Rectangle.Width, this.yellowButton.Rectangle.Height);
                        this.soundEffects[3].Play();
                        break;
                }
            }

            this.active = "YOU";
            this.playingBack = false;
        }

        private void PlaybackAnimation()
        {
            if (this.greenClicked)
            {
                this.greenButton.Rectangle = new Rectangle(this.greenButton.Rectangle.X, this.greenButton.Rectangle.Y + 50, this.greenButton.Rectangle.Width, this.greenButton.Rectangle.Height);
                Thread.Sleep(200);
                this.greenButton.Rectangle = new Rectangle(this.greenButton.Rectangle.X, this.greenButton.Rectangle.Y - 50, this.greenButton.Rectangle.Width, this.greenButton.Rectangle.Height);
                this.greenClicked = false;
                this.soundEffects[0].Play();
            }
            else if (this.redClicked)
            {
                this.redButton.Rectangle = new Rectangle(this.redButton.Rectangle.X, this.redButton.Rectangle.Y + 50, this.redButton.Rectangle.Width, this.redButton.Rectangle.Height);
                Thread.Sleep(200);
                this.redButton.Rectangle = new Rectangle(this.redButton.Rectangle.X, this.redButton.Rectangle.Y - 50, this.redButton.Rectangle.Width, this.redButton.Rectangle.Height);
                this.redClicked = false;
                this.soundEffects[1].Play();
            }
            else if (this.blueClicked)
            {
                this.blueButton.Rectangle = new Rectangle(this.blueButton.Rectangle.X, this.blueButton.Rectangle.Y + 50, this.blueButton.Rectangle.Width, this.blueButton.Rectangle.Height);
                Thread.Sleep(200);
                this.blueButton.Rectangle = new Rectangle(this.blueButton.Rectangle.X, this.blueButton.Rectangle.Y - 50, this.blueButton.Rectangle.Width, this.blueButton.Rectangle.Height);
                this.blueClicked = false;
                this.soundEffects[2].Play();
            }
            else if (this.yellowClicked)
            {
                this.yellowButton.Rectangle = new Rectangle(this.yellowButton.Rectangle.X, this.yellowButton.Rectangle.Y + 50, this.yellowButton.Rectangle.Width, this.yellowButton.Rectangle.Height);
                Thread.Sleep(200);
                this.yellowButton.Rectangle = new Rectangle(this.yellowButton.Rectangle.X, this.yellowButton.Rectangle.Y - 50, this.yellowButton.Rectangle.Width, this.yellowButton.Rectangle.Height);
                this.yellowClicked = false;
                this.soundEffects[3].Play();
            }
        }

        private void SetBufferTimer(GameTime gameTime)
        {
            this.elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            this.timer -= this.elapsedTime;
            if (this.timer < 0)
            {
                this.allowedToContinue = true;
            }
        }

        private void QuitGame()
        {
            this.SaveResults();
            this.StateManager.States.Pop();
        }

        private void SaveResults()
        {
            using (StreamWriter writer = new StreamWriter(GlobalConstants.SimonSaysHighScorePath, true))
            {
                writer.WriteLine(this.bestScore);
            }
        }
    }
}
