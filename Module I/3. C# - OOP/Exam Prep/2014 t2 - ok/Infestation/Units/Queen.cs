namespace Infestation.Units
{
    using System.Collections.Generic;
    using System.Linq;

    public class Queen : Unit
    {
        public const int QueenPower = 1;
        public const int QueenHealth = 30;
        public const int QueenAggression = 1;

        public Queen(string id)
            : base(id, UnitClassification.Psionic, QueenHealth, QueenPower, QueenAggression)
        {
        }

        public override Interaction DecideInteraction(IEnumerable<UnitInfo> units)
        {
            IEnumerable<UnitInfo> attackableUnits = units.Where((unit) => this.CanAttackUnit(unit));

            UnitInfo optimalAttackableUnit = GetOptimalAttackableUnit(attackableUnits);

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
