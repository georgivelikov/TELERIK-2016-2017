namespace BrainGames.Models.MenuState
{
    using global::BrainGames.Models.MemoryMatrixState;
    using global::BrainGames.Models.SimonSaysState;
    using global::BrainGames.Utilities.Enumerations;

    using Microsoft.Xna.Framework;

    using Models.BaseModels.Boxes;

    using Utilities.Constants;
    using Utilities.Textures;

    public class MenuState : State
    {
        private RegularBox difficultyBox;
        private ClickableBox difficultyBoxEasy;
        private ClickableBox difficultyBoxNormal;
        private ClickableBox difficultyBoxHard;
        private ClickableBox highScoresBox;
        private ClickableBox exitBox;
        private RegularBox selectBox;
        private ClickableBox selectBoxAccuracyTrainer;
        private ClickableBox selectBoxMemoryMatrix;
        private ClickableBox selectBoxEagleEye;
        private ClickableBox selectBoxSimonSays;

        public MenuState(Background background, GameStateManager gsm, Textures textures)
            : base(background, gsm, textures)
        {
            this.InitializeObjects();
        }

        public override void Update(GameTime gameTime)
        {
            if (this.difficultyBoxEasy.CheckForClick())
            {
                this.difficultyBoxEasy.Texture = this.GameTextures.GetTexture("DifficultyEasySelected");
                this.difficultyBoxNormal.Texture = this.GameTextures.GetTexture("DifficultyNormal");
                this.difficultyBoxHard.Texture = this.GameTextures.GetTexture("DifficultyHard");
                this.StateManager.Difficulty = DifficultyType.Easy;
            }

            if (this.difficultyBoxNormal.CheckForClick())
            {
                this.difficultyBoxEasy.Texture = this.GameTextures.GetTexture("DifficultyEasy");
                this.difficultyBoxNormal.Texture = this.GameTextures.GetTexture("DifficultyNormalSelected");
                this.difficultyBoxHard.Texture = this.GameTextures.GetTexture("DifficultyHard");
                this.StateManager.Difficulty = DifficultyType.Normal;
            }

            if (this.difficultyBoxHard.CheckForClick())
            {
                this.difficultyBoxEasy.Texture = this.GameTextures.GetTexture("DifficultyEasy");
                this.difficultyBoxNormal.Texture = this.GameTextures.GetTexture("DifficultyNormal");
                this.difficultyBoxHard.Texture = this.GameTextures.GetTexture("DifficultyHardSelected");
                this.StateManager.Difficulty = DifficultyType.Hard;
            }

            if (this.selectBoxAccuracyTrainer.CheckForClick())
            {
                Background accuracyTrainerBackground = new Background(this.GameTextures.GetTexture("MemoryMatrixBackground"));
                this.StateManager.States.Push(new AccuracyTrainerState(accuracyTrainerBackground, this.StateManager, this.GameTextures));
            }

            if (this.selectBoxMemoryMatrix.CheckForClick())
            {
                Background memoryMatrixBackground = new Background(this.GameTextures.GetTexture("MemoryMatrixBackground"));
                this.StateManager.States.Push(new MemoryMatrixState(memoryMatrixBackground, this.StateManager, this.GameTextures));
            }

            if (this.selectBoxEagleEye.CheckForClick())
            {
                //this.StateManager.States.Push(new EagleEyeState());
            }

            if (this.selectBoxSimonSays.CheckForClick())
            {
                Background simonSaysBackground = new Background(this.GameTextures.GetTexture("SimonSaysBackground"));
                this.StateManager.States.Push(new SimonSaysState(simonSaysBackground, this.StateManager, this.GameTextures));
            }

            if (this.highScoresBox.CheckForClick())
            {
                Background accuracyTrainerBackground = new Background(this.GameTextures.GetTexture("MemoryMatrixBackground"));
                this.StateManager.States.Push(new HighScoreState(accuracyTrainerBackground, this.StateManager, this.GameTextures));
            }

            if (this.exitBox.CheckForClick())
            {
                this.StateManager.Game.Exit();
            }
        }

        private void InitializeObjects()
        {
            this.difficultyBox = new RegularBox(
                this.GameTextures.GetTexture("DifficultyBox"), 
                new Rectangle(
                    MenuStateConstants.DifficultyBoxStartingX, 
                    MenuStateConstants.DifficultyBoxStartingY,
                    MenuStateConstants.DifficultyBoxWidth,
                    MenuStateConstants.DifficultyBoxHeight));
            this.ListOfObjects.Add(this.difficultyBox);

            this.highScoresBox = new ClickableBox(
                this.GameTextures.GetTexture("HighScoresBox"),
                new Rectangle(
                    MenuStateConstants.HighScoreBoxStartingX,
                    MenuStateConstants.HighScoreBoxStartingY,
                    MenuStateConstants.HighScoreBoxWidth,
                    MenuStateConstants.HighScoreBoxHeight));
            this.ListOfObjects.Add(this.highScoresBox);

            this.exitBox = new ClickableBox(
                this.GameTextures.GetTexture("ExitBox"),
                new Rectangle(
                    MenuStateConstants.ExitBoxStartingX,
                    MenuStateConstants.ExitBoxStartingY,
                    MenuStateConstants.ExitBoxWidth,
                    MenuStateConstants.ExitBoxHeight));
            this.ListOfObjects.Add(this.exitBox);

            this.selectBox = new RegularBox(
                this.GameTextures.GetTexture("SelectBox"),
                new Rectangle(
                    MenuStateConstants.SelectBoxStartingX,
                    MenuStateConstants.SelectBoxStartingY,
                    MenuStateConstants.SelectBoxWidth,
                    MenuStateConstants.SelectBoxHeight));
            this.ListOfObjects.Add(this.selectBox);

            this.difficultyBoxEasy = new ClickableBox(
                this.GameTextures.GetTexture("DifficultyEasySelected"), // default difficulty will be easy
                new Rectangle(
                    MenuStateConstants.DifficultySelectBoxX,
                    MenuStateConstants.DifficultySelectBoxY1,
                    MenuStateConstants.DifficultySelectBoxWidth,
                    MenuStateConstants.DifficultySelectBoxHeight));
            this.ListOfObjects.Add(this.difficultyBoxEasy);

            this.difficultyBoxNormal = new ClickableBox(
                this.GameTextures.GetTexture("DifficultyNormal"), // default difficulty will be easy
                new Rectangle(
                    MenuStateConstants.DifficultySelectBoxX,
                    MenuStateConstants.DifficultySelectBoxY2,
                    MenuStateConstants.DifficultySelectBoxWidth,
                    MenuStateConstants.DifficultySelectBoxHeight));
            this.ListOfObjects.Add(this.difficultyBoxNormal);

            this.difficultyBoxHard = new ClickableBox(
                this.GameTextures.GetTexture("DifficultyHard"), // default difficulty will be easy
                new Rectangle(
                    MenuStateConstants.DifficultySelectBoxX,
                    MenuStateConstants.DifficultySelectBoxY3,
                    MenuStateConstants.DifficultySelectBoxWidth,
                    MenuStateConstants.DifficultySelectBoxHeight));
            this.ListOfObjects.Add(this.difficultyBoxHard);

            this.selectBoxAccuracyTrainer = new ClickableBox(
                this.GameTextures.GetTexture("SelectBoxAccuracy"),
                new Rectangle(
                    MenuStateConstants.GameSelectBoxX,
                    MenuStateConstants.GameSelectBoxY1,
                    MenuStateConstants.GameSelectBoxWidth,
                    MenuStateConstants.GameSelectBoxHeight));
            this.ListOfObjects.Add(this.selectBoxAccuracyTrainer);

            this.selectBoxMemoryMatrix = new ClickableBox(
                this.GameTextures.GetTexture("SelectBoxMemoryMatrix"),
                new Rectangle(
                    MenuStateConstants.GameSelectBoxX,
                    MenuStateConstants.GameSelectBoxY2,
                    MenuStateConstants.GameSelectBoxWidth,
                    MenuStateConstants.GameSelectBoxHeight));
            this.ListOfObjects.Add(this.selectBoxMemoryMatrix);

            this.selectBoxEagleEye = new ClickableBox(
                this.GameTextures.GetTexture("SelectBoxEagleEye"),
                new Rectangle(
                    MenuStateConstants.GameSelectBoxX,
                    MenuStateConstants.GameSelectBoxY3,
                    MenuStateConstants.GameSelectBoxWidth,
                    MenuStateConstants.GameSelectBoxHeight));
            this.ListOfObjects.Add(this.selectBoxEagleEye);

            this.selectBoxSimonSays = new ClickableBox(
                this.GameTextures.GetTexture("SelectBoxSimonSays"),
                new Rectangle(
                    MenuStateConstants.GameSelectBoxX,
                    MenuStateConstants.GameSelectBoxY4,
                    MenuStateConstants.GameSelectBoxWidth,
                    MenuStateConstants.GameSelectBoxHeight));
            this.ListOfObjects.Add(this.selectBoxSimonSays);
        }
    }
}
