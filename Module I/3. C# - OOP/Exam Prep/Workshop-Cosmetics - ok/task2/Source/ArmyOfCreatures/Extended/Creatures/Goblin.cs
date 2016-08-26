namespace ArmyOfCreatures.Extended.Creatures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using ArmyOfCreatures.Logic.Creatures;

    public class Goblin : Creature
    {
        public const int GoblinAttack = 4;
        public const int GoblinDeffence = 2;
        public const int GoblinHealthPoints = 5;
        public const decimal GoblinDamage = 1.5m;

        public Goblin()
            : base(GoblinAttack, GoblinDeffence, GoblinHealthPoints, GoblinDamage)
        {
        }
    }
}
