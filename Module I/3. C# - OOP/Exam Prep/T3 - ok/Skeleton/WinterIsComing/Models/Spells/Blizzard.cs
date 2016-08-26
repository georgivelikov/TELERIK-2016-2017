namespace WinterIsComing.Models.Spells
{
    public class Blizzard : Spell
    {
        public const int DefaultEnergyCost = 40;

        public Blizzard(int damage)
            : base(damage, DefaultEnergyCost)
        {
        }
    }
}
