namespace WinterIsComing.Models.Units
{
    using WinterIsComing.Contracts;
    using WinterIsComing.Models.CombatHandlers;

    public class IceGiant : Unit
    {
        private const int DefaultRange = 1;
        private const int DefaultAttackPoints = 150;
        private const int DefaultHealthPoints = 300;
        private const int DefaultDefensePoints = 60;
        private const int DefaultEnergyPoints = 50;

        private ICombatHandler combatHandler;

        public IceGiant(int x, int y, string name)
            : base(x, y, name, DefaultRange, DefaultAttackPoints, DefaultHealthPoints, DefaultDefensePoints, DefaultEnergyPoints)
        {
            this.combatHandler = new IceGiantCombatHandler(this);
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
