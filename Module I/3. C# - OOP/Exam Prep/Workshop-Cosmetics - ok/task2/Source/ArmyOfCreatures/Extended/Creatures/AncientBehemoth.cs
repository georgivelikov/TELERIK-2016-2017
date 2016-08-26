namespace ArmyOfCreatures.Extended.Creatures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using ArmyOfCreatures.Logic.Creatures;
    using ArmyOfCreatures.Logic.Specialties;

    public class AncientBehemoth : Creature
    {
        public const int AncienBehemothAttack = 19;
        public const int AncienBehemothDefence = 19;
        public const int AncienBehemothHealthPoints = 300;
        public const decimal AncienBehemothDamage = 40m;

        public const decimal AncienBehemothDamageReduce = 80m;
        public const int AncienBehemothDoubleDefenceRounds = 5;

        public AncientBehemoth() 
            : base(AncienBehemothAttack, AncienBehemothDefence, AncienBehemothHealthPoints, AncienBehemothDamage)
        {
            this.AddSpecialty(new ReduceEnemyDefenseByPercentage(AncienBehemothDamageReduce));
            this.AddSpecialty(new DoubleDefenseWhenDefending(AncienBehemothDoubleDefenceRounds));
        }
    }
}
