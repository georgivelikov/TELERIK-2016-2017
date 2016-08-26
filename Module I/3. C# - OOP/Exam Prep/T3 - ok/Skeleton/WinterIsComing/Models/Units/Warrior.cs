namespace WinterIsComing.Models.Units
{
    using WinterIsComing.Contracts;
    using WinterIsComing.Models.CombatHandlers;

    public class Warrior : Unit
    {
        private const int DefaultRange = 1;
        private const int DefaultAttackPoints = 120;
        private const int DefaultHealthPoints = 180;
        private const int DefaultDefensePoints = 70;
        private const int DefaultEnergyPoints = 60;
        private ICombatHandler combarHandler;

        public Warrior(int x, int y, string name)
            : base(x, y, name, DefaultRange, DefaultAttackPoints, DefaultHealthPoints, DefaultDefensePoints, DefaultEnergyPoints)
        {
            this.combarHandler = new WarriorCombatHandler(this);
        }

        public override ICombatHandler CombatHandler
        {
            get
            {
                return this.combarHandler;
            }
        }
    }
}
