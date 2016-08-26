namespace Infestation.Suplements
{
    public class InfestationSpores : Supplement
    {
        private const int PowerEff = -1;
        private const int HealthEff = 0;
        private const int AggressionEff = 20;

        public InfestationSpores()
            : base(PowerEff, HealthEff, AggressionEff)
        {
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (this.GetType().Name == otherSupplement.GetType().Name)
            {
                this.PowerEffect = 0;
                this.HealthEffect = 0;
                this.AggressionEffect = 0;
            }
        }
    }
}
