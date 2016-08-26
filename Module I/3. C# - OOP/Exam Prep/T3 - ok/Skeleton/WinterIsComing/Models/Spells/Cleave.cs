namespace WinterIsComing.Models.Spells
{
    public class Cleave : Spell
    {
        public const int DefaultEnergyCost = 15;

        public Cleave(int damage)
            : base(damage, DefaultEnergyCost)
        {
        }
    }
}
