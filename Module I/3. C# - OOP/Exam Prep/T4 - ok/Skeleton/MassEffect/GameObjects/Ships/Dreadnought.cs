using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassEffect.GameObjects.Ships
{
    using MassEffect.GameObjects.Locations;
    using MassEffect.GameObjects.Projectiles;
    using MassEffect.Interfaces;

    public class Dreadnought : Starship
    {
        private const int DefaultHealth = 200;
        private const int DefaultShields = 300;
        private const int DefaultDamage = 150;
        private const double DefaultFuel = 700;
        private const int ShieldBonus = 50;

        public Dreadnought(string name, StarSystem location)
            : base(name, DefaultHealth, DefaultShields, DefaultDamage, DefaultFuel, location)
        {
        }

        public override IProjectile ProduceAttack()
        {
            return new Laser(this.Damage + this.Shields / 2);
        }

        public override void RespondToAttack(IProjectile attack)
        {
            this.Shields += ShieldBonus;
            attack.Hit(this);
            this.Shields -= ShieldBonus;
        } 
    }
}
