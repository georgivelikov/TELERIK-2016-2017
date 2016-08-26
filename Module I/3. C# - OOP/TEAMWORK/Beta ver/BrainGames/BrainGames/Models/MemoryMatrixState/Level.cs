namespace BrainGames.Models.MemoryMatrixState.LevelMaps
{
    public class Level
    {
        private int[,] map;
        private int numberOfBlocks;
        private int levelNumber;

        public Level(int levelNumber, int numberOfBlocks, int[,] map)
        {
            this.LevelNumber = levelNumber;
            this.NumberOfBlocks = numberOfBlocks;
            this.Map = map;
        }

        public int[,] Map
        {
            get
            {
                return this.map;
            }

            private set
            {
                this.map = value;
            }
        }

        public int NumberOfBlocks
        {
            get
            {
                return this.numberOfBlocks;
            }

            private set
            {
                this.numberOfBlocks = value;
            }
        }

        public int LevelNumber
        {
            get
            {
                return this.levelNumber;
            }

            private set
            {
                this.levelNumber = value;
            }
        }
    }
}
