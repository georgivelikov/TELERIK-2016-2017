namespace WinterIsComing.Core
{
    using System.Collections.Generic;

    using WinterIsComing.Contracts;

    public class UnitEffector : IUnitEffector
    {
        private const int HealthBonus = 50;

        public void ApplyEffect(IEnumerable<IUnit> units)
        {
            foreach (var unit in units)
            {
                unit.HealthPoints += HealthBonus;
            }
        }
    }
}
