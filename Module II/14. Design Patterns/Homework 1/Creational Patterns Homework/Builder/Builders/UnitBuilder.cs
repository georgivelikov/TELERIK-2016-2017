using Builder.Models;

namespace Builder.Builders
{
    public abstract class UnitBuilder
    {
        public Unit Unit { get; set; }

        public abstract void BuildLife();

        public abstract void BuildMana();

        public abstract void BuildAttackPoints();

        public abstract void BuildDeffencePoints();
    }
}
