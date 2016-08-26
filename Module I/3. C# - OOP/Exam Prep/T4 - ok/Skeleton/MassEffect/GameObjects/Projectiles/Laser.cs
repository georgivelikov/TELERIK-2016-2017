namespace MassEffect.GameObjects.Projectiles
{
    using MassEffect.Interfaces;

    public class Laser : Projectile
    {
        public Laser(int damage)
            : base(damage)
        {
        }

        public override void Hit(IStarship ship)
        {
            int excessDamage = this.Damage - ship.Shields;
            if (ship.Shields > 0)
            {
                ship.Shields -= this.Damage;
                if (ship.Shields <= 0)
                {
                    ship.Health -= excessDamage;
                }
            }
            else
            {
                ship.Health -= this.Damage;
            }
        }
    }
}
