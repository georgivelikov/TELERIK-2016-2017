namespace State.States
{
    public abstract class Position
    {
        private int skill = 0;

        private int penalty = 50;

        private int bonus = 100;

        public Position(Developer developer)
        {
            this.Developer = developer;
        }

        public Developer Developer { get; set; }

        public int Skill
        {
            get
            {
                return this.skill;
            }

            protected set
            {
                this.skill = value;
            }
        }

        public virtual void ReadDependencyInjection()
        {
            this.skill += this.bonus;
        }

        public virtual void DrinkAlcohol()
        {
            this.skill -= this.skill;
        }

        public abstract string DoJob();
    }
}
