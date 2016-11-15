using Builder.Models;

namespace Builder.Builders
{
    public class MageBuilder : UnitBuilder
    {
        public MageBuilder()
        {
            this.Unit = new Unit("Mage");
        }

        public override void BuildLife()
        {
            this.Unit["life"] = 300;
        }

        public override void BuildMana()
        {
            this.Unit["mana"] = 150;
        }

        public override void BuildAttackPoints()
        {
            this.Unit["attackPoints"] = 65;
        }

        public override void BuildDeffencePoints()
        {
            this.Unit["deffencePoints"] = 10;
        }
    }
}

