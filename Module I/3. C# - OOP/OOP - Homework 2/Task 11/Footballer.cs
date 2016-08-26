namespace Task_11
{
    [Version(2016, 06)]
    public class Footballer
    {
        private string name;
        private int number;

        public Footballer(string name, int number)
        {
            this.Name = name;
            this.Number = number;
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

        public int Number
        {
            get
            {
                return this.number;
            }

            set
            {
                this.number = value;
            }
        }

        public override string ToString()
        {
            return this.Name + " No " + this.Number;
        }
    }
}
