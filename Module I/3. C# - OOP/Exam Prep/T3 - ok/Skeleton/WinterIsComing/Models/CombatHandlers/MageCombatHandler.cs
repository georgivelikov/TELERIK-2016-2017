namespace WinterIsComing.Models.CombatHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using WinterIsComing.Contracts;
    using WinterIsComing.Core;
    using WinterIsComing.Core.Exceptions;
    using WinterIsComing.Models.Spells;

    public class MageCombatHandler : CombatHandler
    {
        private bool currentFireSpell;
        private ISpell fireSpell;
        private ISpell blizzardSpell;

        public MageCombatHandler(IUnit unit)
            : base(unit)
        {
            this.fireSpell = new FireBreath(this.Unit.AttackPoints);
            this.blizzardSpell = new Blizzard(this.Unit.AttackPoints * 2);
            this.currentFireSpell = true;
        }

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            var selectedTargets =
                    candidateTargets.OrderByDescending(t => t.HealthPoints).ThenBy(t => t.Name).Take(3).ToList();
            return selectedTargets;
        }

        public override ISpell GenerateAttack()
        {
            ISpell currentSpell;
            if (this.currentFireSpell)
            {
                currentSpell = this.fireSpell;
            }
            else
            {
                currentSpell = this.blizzardSpell;
            }

            if (this.Unit.EnergyPoints < currentSpell.EnergyCost)
            {
                throw new NotEnoughEnergyException(string.Format(GlobalMessages.NotEnoughEnergy, this.Unit.Name, currentSpell.GetType().Name));
            }

            this.Unit.EnergyPoints -= currentSpell.EnergyCost;
            this.currentFireSpell = !this.currentFireSpell;

            return currentSpell;
        }

    }
}
