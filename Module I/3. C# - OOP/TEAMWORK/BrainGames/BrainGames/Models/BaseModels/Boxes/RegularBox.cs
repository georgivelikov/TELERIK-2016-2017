namespace BrainGames.Models.BaseModels.Boxes
{
    using MenuState;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class RegularBox : Box
    {
        public RegularBox(Texture2D texture, Rectangle rectangle)
            : base(texture, rectangle)
        {
        }
    }
}
