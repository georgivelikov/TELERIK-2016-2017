namespace BrainGames.Models.MemoryMatrixState
{
    using System.Collections.Generic;

    using global::BrainGames.Interfaces;
    using global::BrainGames.Models.CustomExceptions;
    using global::BrainGames.Utilities.Constants;
    using global::BrainGames.Utilities.Textures;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class Block : GameObject, IClickable, IHoverable
    {
        private int code;
        private bool isTurned;
        private bool isCalculateToScore;
        private Textures textures;

        public Block(Texture2D texture, Rectangle rectangle, int code, Textures textures)
            : base(texture, rectangle)
        {
            this.Code = code;
            this.IsTurned = true;
            this.textures = textures;
        }

        public int Code
        {
            get
            {
                return this.code;
            }

            set
            {
                if (value != 1 && value != 0 && value != 2 && value != 3)
                {
                    throw new BlockCodeException("Code of the block must be 0, 1, 2, 3!");
                }

                this.code = value;
            }
        }

        public bool IsTurned
        {
            get
            {
                return this.isTurned;
            }

            set
            {
                this.isTurned = value;
            }
        }

        public bool IsCalculatedToScore
        {
            get
            {
                return this.isCalculateToScore;
            }

            set
            {
                this.isCalculateToScore = value;
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (!this.IsTurned)
            {
                if (this.CheckForHover())
                {
                    this.Texture = this.textures.GetTexture("HoverBlock");
                }
                else
                {
                    this.Texture = this.textures.GetTexture("DeffaultBlock");             
                }

                if (this.CheckForClick())
                {
                    if (this.Code != MemoryMatrixConstants.TurnedCorrectCode && this.Code != MemoryMatrixConstants.TurnedWrongCode)
                    {
                        if (this.Code == MemoryMatrixConstants.CorrectBlockCode)
                        {
                            // change texture to correct
                            this.Texture = this.textures.GetTexture("CorrectBlock");
                            this.Code = MemoryMatrixConstants.TurnedCorrectCode;
                        }

                        if (this.Code == MemoryMatrixConstants.DefaultBlockCode)
                        {
                            // change texture to wrong
                            this.Texture = this.textures.GetTexture("WrongBlock");
                            this.Code = MemoryMatrixConstants.TurnedWrongCode;
                        }

                        this.IsTurned = true;
                    }
                }
            }

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.Rectangle, Color.White);
        }

        public bool CheckForClick()
        {
            var mouseState = Mouse.GetState();
            var mousePosition = new Point(mouseState.X, mouseState.Y);
            if (this.Rectangle.Contains(mousePosition))
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    return true;
                }
            }

            return false;
        }

        public bool CheckForHover()
        {
            var mouseState = Mouse.GetState();
            var mousePosition = new Point(mouseState.X, mouseState.Y);
            if (this.Rectangle.Contains(mousePosition) && this.Code != MemoryMatrixConstants.TurnedCorrectCode && this.Code != MemoryMatrixConstants.TurnedWrongCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
