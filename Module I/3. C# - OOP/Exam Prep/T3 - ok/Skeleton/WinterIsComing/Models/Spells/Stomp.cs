namespace WinterIsComing.Models.Spells
{
    public class Stomp : Spell
    {
        public const int DefaultEnergyCost = 10;

        public Stomp(int damage)
            : base(damage, DefaultEnergyCost)
        {
        }
    }
}
