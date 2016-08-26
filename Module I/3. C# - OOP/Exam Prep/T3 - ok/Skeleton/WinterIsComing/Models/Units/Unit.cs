namespace WinterIsComing.Models.Units
{
    using System;
    using System.Text;

    using Contracts;

    public abstract class Unit : IUnit
    {
        private readonly string name;
        private readonly int range;
        private int x;
        private int y;
        private int attackPoints;
        private int healthPoints;
        private int defensePoints;
        private int energyPoints;

        public Unit(int x, int y, string name, int range, int attackPoints, int healthPoints, int defensePoints, int energyPoints)
        {
            this.ValidateName(name);
            this.ValidateRange(range);
            this.name = name;
            this.range = range;
            this.X = x;
            this.Y = y;
            this.AttackPoints = attackPoints;
            this.HealthPoints = healthPoints;
            this.DefensePoints = defensePoints;
            this.EnergyPoints = energyPoints;
        }

        public int X
        {
            get
            {
                return this.x;
            }

            set
            {
                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }

            set
            {
                this.y = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public int Range
        {
            get
            {
                return this.range;
            }
        }

        public int AttackPoints
        {
            get
            {
                return this.attackPoints;
            }

            set
            {
                this.attackPoints = value;
            }
        }

        public int HealthPoints
        {
            get
            {
                return this.healthPoints;
            }

            set
            {
                this.healthPoints = value;
            }
        }

        public int DefensePoints
        {
            get
            {
                return this.defensePoints;
            }

            set
            {
                this.defensePoints = value;
            }
        }

        public int EnergyPoints
        {
            get
            {
                return this.energyPoints;
            }

            set
            {
                this.energyPoints = value;
            }
        }

        public abstract ICombatHandler CombatHandler { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(">{0} - {1} at ({2},{3})\n", this.Name, this.GetType().Name, this.X, this.Y);
            if (this.HealthPoints > 0)
            {
                sb.AppendFormat("-Health points = {0}\n", this.HealthPoints);
                sb.AppendFormat("-Attack points = {0}\n", this.AttackPoints);
                sb.AppendFormat("-Defense points = {0}\n", this.DefensePoints);
                sb.AppendFormat("-Energy points = {0}\n", this.EnergyPoints);
                sb.AppendFormat("-Range = {0}\n", this.Range);
            }
            else
            {
                sb.AppendFormat("(Dead)\n");
            }

            return sb.ToString().Trim();
        }

        private void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Must have name");
            }
        }

        private void ValidateRange(int range)
        {
            if (range < 0)
            {
                throw new ArgumentException("Must be positive");
            }
        }
    }
}
