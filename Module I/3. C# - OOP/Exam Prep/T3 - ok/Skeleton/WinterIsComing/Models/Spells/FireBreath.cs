namespace WinterIsComing.Models.Spells
{
    public class FireBreath : Spell
    {
        private const int DefaultEnergyCost = 30;

        public FireBreath(int damage)
            : base(damage, DefaultEnergyCost)
        {
        }
    }
}
