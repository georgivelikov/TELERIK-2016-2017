namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using WarMachines.Interfaces;

    public abstract class Machine : IMachine
    {
        private string name;
        private IPilot pilot = null;
        private double healthPoints;
        private double attackPoints;
        private double defensePoints;
        private IList<string> targets;


        public Machine(string name, double healthPoints, double attackPoints, double defensePoints)
        {
            this.Name = name;
            this.HealthPoints = healthPoints;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.targets = new List<string>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name can not be null or empty");
                }

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }

            set
            {
                // check for null
                this.pilot = value;
            }
        }

        public double HealthPoints
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

        public double AttackPoints
        {
            get
            {
                return this.attackPoints;
            }

            protected set
            {
                this.attackPoints = value;
            }
        }

        public double DefensePoints
        {
            get
            {
                return this.defensePoints;
            }

            protected set
            {
                this.defensePoints = value;
            }
        }

        public IList<string> Targets
        {
            get
            {
                return this.targets;
            }
        }

        public void Attack(string target)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("- {0}\n", this.Name);
            sb.AppendFormat(" *Type: {0}\n", this.GetType().Name);
            sb.AppendFormat(" *Health: {0}\n", this.HealthPoints);
            sb.AppendFormat(" *Attack: {0}\n", this.AttackPoints);
            sb.AppendFormat(" *Defense: {0}\n", this.DefensePoints);
            string formatedTarges = string.Empty;
            if (this.targets.Count == 0)
            {
                formatedTarges = "None";
            }
            else
            {
                formatedTarges = string.Join(", ", this.targets);
            }

            sb.AppendFormat(" *Targets: {0}\n", formatedTarges);

            return sb.ToString().Trim();
        }
    }
}
