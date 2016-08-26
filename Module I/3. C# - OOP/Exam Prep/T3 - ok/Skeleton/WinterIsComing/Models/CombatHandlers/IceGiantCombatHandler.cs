namespace WinterIsComing.Models.CombatHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using WinterIsComing.Contracts;
    using WinterIsComing.Core;
    using WinterIsComing.Core.Exceptions;
    using WinterIsComing.Models.Spells;

    public class IceGiantCombatHandler : CombatHandler
    {
        private const int IceGiantMinHealth = 150;
        private const int IceGiantAttackBonus = 5;

        public IceGiantCombatHandler(IUnit unit)
            : base(unit)
        {
        }

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            if (this.Unit.HealthPoints <= IceGiantMinHealth)
            {
                var selectedTargets = candidateTargets.Take(1).ToList();
                return selectedTargets;
            }
            else
            {
                var selectedTargets = candidateTargets.ToList();
                return selectedTargets;
            }
        }

        public override ISpell GenerateAttack()
        {
            var currentSpell = new Stomp(this.Unit.AttackPoints);
            if (this.Unit.EnergyPoints < currentSpell.EnergyCost)
            {
                throw new NotEnoughEnergyException(string.Format(GlobalMessages.NotEnoughEnergy, this.Unit.Name, currentSpell.GetType().Name));
            }

            this.Unit.EnergyPoints -= currentSpell.EnergyCost;
            this.Unit.AttackPoints += IceGiantAttackBonus;

            return currentSpell;
        }
    }
}
