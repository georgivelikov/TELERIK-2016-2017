using System.Collections.Generic;

namespace WinterIsComing.Models.CombatHandlers
{
    using WinterIsComing.Contracts;

    public abstract class CombatHandler : ICombatHandler
    {
        public CombatHandler(IUnit unit)
        {
            this.Unit = unit;
        }

        public IUnit Unit { get; set; }

        public abstract IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets);

        public abstract ISpell GenerateAttack();

        
    }
}
