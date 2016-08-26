namespace Infestation.Units
{
    public class Tank : Unit
    {
        public const int TankPower = 25;
        public const int TankHealth = 20;
        public const int TankAggression = 25;

        public Tank(string id)
            : base(id, UnitClassification.Mechanical, TankHealth, TankPower, TankAggression)
        {
        }
    }
}
