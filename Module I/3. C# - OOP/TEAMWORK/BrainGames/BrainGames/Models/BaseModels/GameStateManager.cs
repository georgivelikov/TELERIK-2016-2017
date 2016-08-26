namespace BrainGames.Models
{
    using System.Collections.Generic;

    using global::BrainGames.Interfaces;
    using global::BrainGames.Utilities.Constants;
    using global::BrainGames.Utilities.Enumerations;

    using Microsoft.Xna.Framework;

    public class GameStateManager : IGameStateManager
    {
        private BrainGames game;
        private Stack<State> states;
        private DifficultyType difficulty = GlobalConstants.StartingDifficulty;

        public GameStateManager(BrainGames game)
        {
            this.Game = game;
            this.states = new Stack<State>();
        }

        public DifficultyType Difficulty
        {
            get
            {
                return this.difficulty;
            }

            set
            {
                this.difficulty = value;
            }
        }

        public BrainGames Game
        {
            get
            {
                return this.game;
            }

            private set
            {
                this.game = value;
            }
        }

        public Stack<State> States
        {
            get
            {
                return this.states;
            }
        }
    }
}
