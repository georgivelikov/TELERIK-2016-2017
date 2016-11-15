namespace State.States
{
    public class Senior : Position
    {
        public Senior(Developer developer)
            : base(developer)
        {
        }

        public override void ReadDependencyInjection()
        {
            base.ReadDependencyInjection();
            if (this.Skill >= 600)
            {
                this.Developer.Position = new Master(this.Developer);
            }
        }

        public override void DrinkAlcohol()
        {
            base.DrinkAlcohol();
            if (this.Skill < 300)
            {
                this.Developer.Position = new Junior(this.Developer);
            }
        }

        public override string DoJob()
        {
            return "I am senior and I do good job";
        }
    }
}
