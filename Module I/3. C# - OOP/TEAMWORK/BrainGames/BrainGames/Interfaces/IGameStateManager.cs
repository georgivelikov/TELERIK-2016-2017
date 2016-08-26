namespace BrainGames.Interfaces
{
    using System.Collections.Generic;

    using global::BrainGames.Utilities.Enumerations;

    using Microsoft.Xna.Framework;

    using Models;

    public interface IGameStateManager
    {
        BrainGames Game { get;  }

        Stack<State> States { get; }

        DifficultyType Difficulty { get; set; }
    }
}
