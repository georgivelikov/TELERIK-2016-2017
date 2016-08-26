namespace Infestation.Units
{
    using System.Collections.Generic;
    using System.Linq;

    public class Parasite : Unit
    {
        public const int ParasitePower = 1;
        public const int ParasiteHealth = 1;
        public const int ParasiteAggression = 1;

        public Parasite(string id)
            : base(id, UnitClassification.Biological, ParasiteHealth, ParasitePower, ParasiteAggression)
        {
        }

        public override Interaction DecideInteraction(IEnumerable<UnitInfo> units)
        {
            IEnumerable<UnitInfo> attackableUnits = units.Where((unit) => this.CanAttackUnit(unit));

            UnitInfo optimalAttackableUnit = this.GetOptimalAttackableUnit(attackableUnits);

            if (optimalAttackableUnit.Id != null)
            {
                return new Interaction(new UnitInfo(this), optimalAttackableUnit, InteractionType.Infest);
            }

            return Interaction.PassiveInteraction;
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            var sorted = attackableUnits.OrderBy(x => x.Health);
            return sorted.FirstOrDefault();
        }

        protected override bool CanAttackUnit(UnitInfo unit)
        {
            bool attackUnit = false;
            if (this.Id != unit.Id && InfestationRequirements.RequiredClassificationToInfest(unit.UnitClassification) == this.UnitClassification)
            {
                return true;
            }

            return attackUnit;
        }
    }
}