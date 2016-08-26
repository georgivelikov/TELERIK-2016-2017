namespace WarMachines.Machines
{
    using System.ComponentModel;
    using System.Text;

    using WarMachines.Interfaces;

    public class Tank : Machine, ITank
    {
        private const double InitialHealthPoint = 100;
        private const bool InitialDeffenseMode = true;

        private const double DefenseBonus = 30;
        private const double AttackPenalty = -40;

        private bool defenseMode;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, InitialHealthPoint, attackPoints, defensePoints)
        {
            this.defenseMode = InitialDeffenseMode;
            this.AttackPoints += AttackPenalty;
            this.DefensePoints += DefenseBonus;
        }

        public bool DefenseMode
        {
            get
            {
                return this.defenseMode;
            }
        }

        public void ToggleDefenseMode()
        {
            this.defenseMode = !this.defenseMode;

            if (this.DefenseMode)
            {
                this.AttackPoints += AttackPenalty;
                this.DefensePoints += DefenseBonus;
            }
            else
            {
                this.AttackPoints -= AttackPenalty;
                this.DefensePoints -= DefenseBonus;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendFormat(" *Defense: {0}", this.DefenseMode ? "ON" : "OFF");

            return sb.ToString().Trim();
        }
    }
}
