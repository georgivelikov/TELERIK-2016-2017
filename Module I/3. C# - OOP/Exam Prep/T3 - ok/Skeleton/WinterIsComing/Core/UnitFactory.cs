namespace WinterIsComing.Core
{
    using System;
    using Contracts;
    using Models;

    using WinterIsComing.Models.Units;

    public static class UnitFactory
    {
        public static IUnit Create(UnitType type, string name, int x, int y)
        {
            IUnit generatedUnit;
            switch (type)
            {
                case UnitType.Warrior:
                    generatedUnit = new Warrior(x, y, name);
                    break;
                case UnitType.Mage:
                    generatedUnit = new Mage(x, y, name);
                    break;
                case UnitType.IceGiant:
                    generatedUnit = new IceGiant(x, y, name);
                    break;
                default:
                    throw new NotImplementedException();
            }

            return generatedUnit;
        }
    }
}
