namespace MassEffect.GameObjects.Ships
{
    using System.Collections.Generic;
    using System.Text;

    using MassEffect.GameObjects.Enhancements;
    using MassEffect.GameObjects.Locations;
    using MassEffect.Interfaces;

    public abstract class Starship : IStarship
    {
        private string name;
        private int health;
        private int shields;
        private int damage;
        private double fuel;
        private StarSystem location;
        private List<Enhancement> enhancements;

        protected Starship(string name, int health, int shields, int damage, double fuel, StarSystem location)
        {
            this.Name = name;
            this.Health = health;
            this.Shields = shields;
            this.Damage = damage;
            this.Fuel = fuel;
            this.Location = location;
            this.enhancements = new List<Enhancement>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }

            set
            {
                this.health = value;
                if (this.health < 0)
                {
                    this.health = 0;
                }
            }
        }

        public int Shields
        {
            get
            {
                return this.shields;
            }

            set
            {
                this.shields = value;
                if (this.shields < 0)
                {
                    this.shields = 0;
                }
            }
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

        public double Fuel
        {
            get
            {
                return this.fuel;
            }

            set
            {
                this.fuel = value;
            }
        }

        public StarSystem Location
        {
            get
            {
                return this.location;
            }

            set
            {
                this.location = value;
            }
        }

        public IEnumerable<Enhancement> Enhancements
        {
            get
            {
                return this.enhancements;
            }
        }

        public void AddEnhancement(Enhancement enhancement)
        {
            this.enhancements.Add(enhancement);
            this.Shields += enhancement.ShieldBonus;
            this.Damage += enhancement.DamageBonus;
            this.Fuel += enhancement.FuelBonus;
        }

        public abstract IProjectile ProduceAttack();

        public abstract void RespondToAttack(IProjectile attack);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("--{0} - {1}\n", this.Name, this.GetType().Name);
            if (this.Health <= 0)
            {
                sb.AppendFormat("(Destroyed)\n");
            }
            else
            {
                sb.AppendFormat("-Location: {0}\n", this.Location.Name);
                sb.AppendFormat("-Health: {0}\n", this.Health);
                sb.AppendFormat("-Shields: {0}\n", this.Shields);
                sb.AppendFormat("-Damage: {0}\n", this.Damage);
                sb.AppendFormat("-Fuel: {0:0.0}\n", this.Fuel);
                sb.AppendFormat("-Enhancements: {0}\n", this.enhancements.Count == 0 ? "N/A" : string.Join(", ", this.enhancements));
            }

            return sb.ToString().Trim();
        }
    }
}
