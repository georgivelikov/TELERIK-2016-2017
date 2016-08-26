namespace MassEffect.GameObjects.Ships
{
    using System.Text;

    using MassEffect.GameObjects.Locations;
    using MassEffect.GameObjects.Projectiles;
    using MassEffect.Interfaces;

    public class Frigate : Starship
    {
        private const int DefaultHealth = 60;
        private const int DefaultShields = 50;
        private const int DefaultDamage = 30;
        private const double DefaultFuel = 220;
        private int projectilesFired = 0;

        public Frigate(string name, StarSystem location)
            : base(name, DefaultHealth, DefaultShields, DefaultDamage, DefaultFuel, location)
        {
        }

        public override IProjectile ProduceAttack()
        {
            this.projectilesFired++;
            return new ShieldReaver(this.Damage);
        }

        public override void RespondToAttack(IProjectile attack)
        {
            attack.Hit(this);
        }

        public override string ToString()
        {
            if (this.Health <= 0)
            {
                return base.ToString();
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(base.ToString());
                sb.AppendFormat("-Projectiles fired: {0}", this.projectilesFired);
                return sb.ToString();
            }
        }
    }
}
