namespace Infestation.Suplements
{
    public class Weapon : Supplement
    {
        private const int PowerEff = 10;
        private const int HealthEff = 0;
        private const int AggressionEff = 3;

        public Weapon()
            : base(0, 0, 0)
        {
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement.GetType().Name == "WeaponrySkill")
            {
                this.PowerEffect = PowerEff;
                this.AggressionEffect = AggressionEff;
            }
        }
    }
}