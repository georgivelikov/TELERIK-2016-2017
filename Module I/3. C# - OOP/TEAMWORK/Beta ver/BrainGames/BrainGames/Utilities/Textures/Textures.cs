namespace BrainGames.Utilities.Textures
{
    using System.Collections.Generic;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Textures
    {
        private static Dictionary<string, Texture2D> texturesAtlas = new Dictionary<string, Texture2D>();
        private static Textures textures = new Textures();

        private Textures()
        {         
        }

        public static Textures GetInstance()
        {
            return textures;
        }

        public Texture2D GetTexture(string textureName)
        {
            return texturesAtlas[textureName];
        }

        public void InitiateTextures(Game game)
        {
            Texture2D menuBackground = game.Content.Load<Texture2D>("../../Content/Images/MenuState/MenuStateBackground.png");
            texturesAtlas.Add("MenuBackground", menuBackground);

            Texture2D difficultyBox = game.Content.Load<Texture2D>("../../Content/Images/MenuState/Difficulty.png");
            texturesAtlas.Add("DifficultyBox", difficultyBox);

            Texture2D highScoresBox = game.Content.Load<Texture2D>("../../Content/Images/MenuState/HighScores.png");
            texturesAtlas.Add("HighScoresBox", highScoresBox);

            Texture2D exitBox = game.Content.Load<Texture2D>("../../Content/Images/MenuState/Exit.png");
            texturesAtlas.Add("ExitBox", exitBox);

            Texture2D selectBox = game.Content.Load<Texture2D>("../../Content/Images/MenuState/SelectGame.png");
            texturesAtlas.Add("SelectBox", selectBox);

            Texture2D difficultyEasy = game.Content.Load<Texture2D>("../../Content/Images/MenuState/DifficultyEasy.png");
            texturesAtlas.Add("DifficultyEasy", difficultyEasy);

            Texture2D difficultyEasySelected = game.Content.Load<Texture2D>("../../Content/Images/MenuState/DifficultyEasySelected.png");
            texturesAtlas.Add("DifficultyEasySelected", difficultyEasySelected);

            Texture2D difficultyNormal = game.Content.Load<Texture2D>("../../Content/Images/MenuState/DifficultyNormal.png");
            texturesAtlas.Add("DifficultyNormal", difficultyNormal);

            Texture2D difficultyNormalSelected = game.Content.Load<Texture2D>("../../Content/Images/MenuState/DifficultyNormalSelected.png");
            texturesAtlas.Add("DifficultyNormalSelected", difficultyNormalSelected);

            Texture2D difficultyHard = game.Content.Load<Texture2D>("../../Content/Images/MenuState/DifficultyHard.png");
            texturesAtlas.Add("DifficultyHard", difficultyHard);

            Texture2D difficultyHardSelected = game.Content.Load<Texture2D>("../../Content/Images/MenuState/DifficultyHardSelected.png");
            texturesAtlas.Add("DifficultyHardSelected", difficultyHardSelected);

            Texture2D selectBoxEagleEye = game.Content.Load<Texture2D>("../../Content/Images/MenuState/EagleEye.png");
            texturesAtlas.Add("SelectBoxEagleEye", selectBoxEagleEye);

            Texture2D selectBoxAccuracy = game.Content.Load<Texture2D>("../../Content/Images/MenuState/AccuracyTrainer.png");
            texturesAtlas.Add("SelectBoxAccuracy", selectBoxAccuracy);

            Texture2D selectBoxMemoryMatrix = game.Content.Load<Texture2D>("../../Content/Images/MenuState/MemoryMatrix.png");
            texturesAtlas.Add("SelectBoxMemoryMatrix", selectBoxMemoryMatrix);

            Texture2D selectBoxPinball = game.Content.Load<Texture2D>("../../Content/Images/MenuState/Pinball.png");
            texturesAtlas.Add("SelectBoxPinball", selectBoxPinball);

            Texture2D selectBoxSimonSays = game.Content.Load<Texture2D>("../../Content/Images/MenuState/SimonSays.png");
            texturesAtlas.Add("SelectBoxSimonSays", selectBoxSimonSays);

            Texture2D memoryMatrixBackground = game.Content.Load<Texture2D>("../../Content/Images/MemoryMatrixState/MemoryMatrixStateBackground.png");
            texturesAtlas.Add("MemoryMatrixBackground", memoryMatrixBackground);

            Texture2D memoryMatrixGameBoard = game.Content.Load<Texture2D>("../../Content/Images/MemoryMatrixState/GameBoardBackground.png");
            texturesAtlas.Add("MemoryMatrixGameBoard", memoryMatrixGameBoard);

            Texture2D deffaultBlock = game.Content.Load<Texture2D>("../../Content/Images/MemoryMatrixState/DeffaultBlock.png");
            texturesAtlas.Add("DeffaultBlock", deffaultBlock);

            Texture2D correctBlock = game.Content.Load<Texture2D>("../../Content/Images/MemoryMatrixState/CorrectBlock.png");
            texturesAtlas.Add("CorrectBlock", correctBlock);

            Texture2D wrongBlock = game.Content.Load<Texture2D>("../../Content/Images/MemoryMatrixState/WrongBlock.png");
            texturesAtlas.Add("WrongBlock", wrongBlock);

            Texture2D hoverBlock = game.Content.Load<Texture2D>("../../Content/Images/MemoryMatrixState/HoverBlock.png");
            texturesAtlas.Add("HoverBlock", hoverBlock);

            Texture2D memoryMatrixUpperMenu = game.Content.Load<Texture2D>("../../Content/Images/MemoryMatrixState/MemoryMatrixUpperMenu.png");
            texturesAtlas.Add("MemoryMatrixUpperMenu", memoryMatrixUpperMenu);

            Texture2D quit = game.Content.Load<Texture2D>("../../Content/Images/MemoryMatrixState/Quit.png");
            texturesAtlas.Add("Quit", quit);

            Texture2D accuracyEasyTarget = game.Content.Load<Texture2D>("../../Content/Images/AccuracyTrainer/BigTarget.png");
            texturesAtlas.Add("AccuracyEasyTarget", accuracyEasyTarget);

            Texture2D accuracyMediumTarget = game.Content.Load<Texture2D>("../../Content/Images/AccuracyTrainer/MediumTarget.png");
            texturesAtlas.Add("AccuracyMediumTarget", accuracyMediumTarget);

            Texture2D accuracyHardTarget = game.Content.Load<Texture2D>("../../Content/Images/AccuracyTrainer/SmallTarget.png");
            texturesAtlas.Add("AccuracyHardTarget", accuracyHardTarget);

            Texture2D accuracyBonusTarget = game.Content.Load<Texture2D>("../../Content/Images/AccuracyTrainer/BonusTarget.png");
            texturesAtlas.Add("AccuracyBonusTarget", accuracyBonusTarget);

            Texture2D accuracyHiddenTarget = game.Content.Load<Texture2D>("../../Content/Images/AccuracyTrainer/HiddenTarget.png");
            texturesAtlas.Add("AccuracyHiddenTarget", accuracyHiddenTarget);

            Texture2D accuracyHitTarget = game.Content.Load<Texture2D>("../../Content/Images/AccuracyTrainer/HitTarget.png");
            texturesAtlas.Add("AccuracyHitTarget", accuracyHitTarget);

            Texture2D highScoreBackground = game.Content.Load<Texture2D>("../../Content/Images/HighScoreState/Background.png");
            texturesAtlas.Add("HighScoreBackground", highScoreBackground);

            Texture2D backButton = game.Content.Load<Texture2D>("../../Content/Images/HighScoreState/Back.png");
            texturesAtlas.Add("BackButton", backButton);

            Texture2D simonSaysBackground = game.Content.Load<Texture2D>("../../Content/Images/SimonSaysState/SimonSaysBackground.png");
            texturesAtlas.Add("SimonSaysBackground", simonSaysBackground);

            Texture2D greenButton = game.Content.Load<Texture2D>("../../Content/Images/SimonSaysState/GreenButton.png");
            texturesAtlas.Add("GreenButton", greenButton);

            Texture2D redButton = game.Content.Load<Texture2D>("../../Content/Images/SimonSaysState/RedButton.png");
            texturesAtlas.Add("RedButton", redButton);

            Texture2D blueButton = game.Content.Load<Texture2D>("../../Content/Images/SimonSaysState/BlueButton.png");
            texturesAtlas.Add("BlueButton", blueButton);

            Texture2D yellowButton = game.Content.Load<Texture2D>("../../Content/Images/SimonSaysState/YellowButton.png");
            texturesAtlas.Add("YellowButton", yellowButton);
        }
    }
}
