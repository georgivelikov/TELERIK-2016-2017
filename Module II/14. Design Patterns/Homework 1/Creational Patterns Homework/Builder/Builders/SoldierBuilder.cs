using Builder.Models;

namespace Builder.Builders
{
    public class SoldierBuilder : UnitBuilder
    {
        public SoldierBuilder()
        {
            this.Unit = new Unit("Soldier");
        }

        public override void BuildLife()
        {
            this.Unit["life"] = 350;
        }

        public override void BuildMana()
        {
            this.Unit["mana"] = 0;
        }

        public override void BuildAttackPoints()
        {
            this.Unit["attackPoints"] = 40;
        }

        public override void BuildDeffencePoints()
        {
            this.Unit["deffencePoints"] = 15;
        }
    }
}
