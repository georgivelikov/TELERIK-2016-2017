namespace BrainGames.Interfaces
{
    using System.Collections.Generic;

    using Models;

    public interface IState : IDrawable, IUpdateable
    {
        Background Background { get; }

        GameStateManager StateManager { get; }

        List<GameObject> ListOfObjects { get; }
    }
}
