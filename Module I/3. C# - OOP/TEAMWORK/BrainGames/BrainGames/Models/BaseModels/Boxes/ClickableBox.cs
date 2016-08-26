namespace BrainGames.Models.BaseModels.Boxes
{
    using Interfaces;

    using MenuState;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class ClickableBox : Box, IClickable
    {
        public ClickableBox(Texture2D texture, Rectangle rectangle)
            : base(texture, rectangle)
        {
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
    }
}
