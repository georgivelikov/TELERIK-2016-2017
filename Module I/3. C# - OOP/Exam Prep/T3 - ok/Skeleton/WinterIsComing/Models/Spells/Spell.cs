namespace WinterIsComing.Models.Spells
{
    using System;

    using Contracts;

    public abstract class Spell : ISpell
    {
        private readonly int damage;
        private readonly int energyCost;

        protected Spell(int damage, int energyCost)
        {
            this.ValidateDamage(damage);
            this.ValidateEnergyCost(energyCost);

            this.damage = damage;
            this.energyCost = energyCost;
        }

        public int Damage
        {
            get
            {
                return this.damage;
            }
        }

        public int EnergyCost
        {
            get
            {
                return this.energyCost;
            }
        }

        private void ValidateDamage(int damage)
        {
            if (damage <= 0)
            {
                throw new ArgumentException("Damage must be positive");
            }
        }

        private void ValidateEnergyCost(int energyCost)
        {
            if (energyCost <= 0)
            {
                throw new ArgumentException("Energy cost must be positive");
            }
        }
    }
}
