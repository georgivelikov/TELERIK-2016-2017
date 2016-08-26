namespace Infestation.Units
{
    using System.Collections.Generic;
    using System.Linq;

    using Infestation.Suplements;

    public class Marine : Human
    {
        public Marine(string id)
            : base(id)
        {
            this.AddSupplement(new WeaponrySkill());
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            return attackableUnits.OrderByDescending(x => x.Health).FirstOrDefault();

        }
    }
}
