namespace MassEffect.GameObjects.Projectiles
{
    using MassEffect.Interfaces;

    public abstract class Projectile : IProjectile
    {
        private int damage;

        public Projectile(int damage)
        {
            this.Damage = damage;
        }

        public int Damage
        {
            get
            {
                return this.damage;
            }

            set
            {
                this.damage = value;
            }
        }

        public abstract void Hit(IStarship ship);

    }
}
