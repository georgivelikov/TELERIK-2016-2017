namespace State.States
{
    public class Junior : Position
    {
        public Junior(Developer developer)
            : base(developer)
        {
        }

        public override void ReadDependencyInjection()
        {
            base.ReadDependencyInjection();
            if (this.Skill >= 300)
            {
                this.Developer.Position = new Senior(this.Developer);
            }
        }

        public override string DoJob()
        {
            return "I am junior and I do bad job";
        }
    }

}
