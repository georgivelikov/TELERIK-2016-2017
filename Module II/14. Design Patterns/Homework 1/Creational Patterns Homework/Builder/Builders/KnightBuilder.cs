using Builder.Models;

namespace Builder.Builders
{
    public class KnightBuilder : UnitBuilder
    {
        public KnightBuilder()
        {
            this.Unit = new Unit("Knight");
        }

        public override void BuildLife()
        {
            this.Unit["life"] = 600;
        }

        public override void BuildMana()
        {
            this.Unit["mana"] = 50;
        }

        public override void BuildAttackPoints()
        {
            this.Unit["attackPoints"] = 80;
        }

        public override void BuildDeffencePoints()
        {
            this.Unit["deffencePoints"] = 25;
        }
    }
}
