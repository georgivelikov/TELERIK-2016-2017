namespace BrainGames.Interfaces
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public interface IGameObject : IDrawable, IUpdateable
    {
        Texture2D Texture { get; set; }

        Rectangle Rectangle { get; set; }
    }
}
