namespace WinterIsComing.Models.Units
{
    using WinterIsComing.Contracts;
    using WinterIsComing.Models.CombatHandlers;

    public class Mage : Unit
    {
        private const int DefaultRange = 2;
        private const int DefaultAttackPoints = 80;
        private const int DefaultHealthPoints = 80;
        private const int DefaultDefensePoints = 40;
        private const int DefaultEnergyPoints = 120;

        private ICombatHandler combatHandler;

        public Mage(int x, int y, string name)
            : base(x, y, name, DefaultRange, DefaultAttackPoints, DefaultHealthPoints, DefaultDefensePoints, DefaultEnergyPoints)
        {
            this.combatHandler = new MageCombatHandler(this);
        }

        public override ICombatHandler CombatHandler
        {
            get
            {
                return this.combatHandler;
            }
        }
    }
}
