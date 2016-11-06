namespace Minesweepers.Models
{
    public class Player
    {
        private string name;

        private int points;

        public Player(string name, int point)
        {
            this.Name = name;
            this.Points = point;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public int Points
        {
            get
            {
                return this.points;
            }

            set
            {
                this.points = value;
            }
        }

    }
}
