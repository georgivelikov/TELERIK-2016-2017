namespace WinterIsComing.Models.CombatHandlers
{
    using System.Collections.Generic;
    using System.Linq;

    using WinterIsComing.Contracts;
    using WinterIsComing.Core;
    using WinterIsComing.Core.Exceptions;
    using WinterIsComing.Models.Spells;

    public class WarriorCombatHandler : CombatHandler
    {
        private const int MinHealthForDamage = 80;
        private const int MinHealthForEnergy = 50;

        public WarriorCombatHandler(IUnit unit)
            : base(unit)
        {
        }

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            // possible NULL
            var selectedTargets = candidateTargets.OrderBy(t => t.HealthPoints).ThenBy(t => t.Name).Take(1).ToList();
            return selectedTargets;
        }

        public override ISpell GenerateAttack()
        {
            var damage = this.Unit.AttackPoints;
            if (this.Unit.HealthPoints <= MinHealthForDamage)
            {
                damage += this.Unit.HealthPoints * 2;
            }

            var currentSpell = new Cleave(damage);
            if (this.Unit.HealthPoints > MinHealthForEnergy)
            {
                if (this.Unit.EnergyPoints < currentSpell.EnergyCost)
                {
                    throw new NotEnoughEnergyException(string.Format(GlobalMessages.NotEnoughEnergy, this.Unit.Name, currentSpell.GetType().Name));
                }

                this.Unit.EnergyPoints -= currentSpell.EnergyCost;
            }

            return currentSpell;
        }
    }
}
