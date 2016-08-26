namespace MassEffect.GameObjects.Ships
{
    using System;

    using MassEffect.GameObjects.Locations;
    using MassEffect.GameObjects.Projectiles;
    using MassEffect.Interfaces;

    public class Cruiser : Starship
    {
        private const int DefaultHealth = 100;
        private const int DefaultShields = 100;
        private const int DefaultDamage = 50;
        private const double DefaultFuel = 300;

        public Cruiser(string name, StarSystem location)
            : base(name, DefaultHealth, DefaultShields, DefaultDamage, DefaultFuel, location)
        {
        }

        public override IProjectile ProduceAttack()
        {
            return new PenetrationShell(this.Damage);
        }

        public override void RespondToAttack(IProjectile attack)
        {
            attack.Hit(this);
        }
    }
}
