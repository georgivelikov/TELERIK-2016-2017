namespace Builder.Directors
{
    using Builder.Builders;

    public class UnitConstructor : IUnitConstructor
    {
        public void Construct(UnitBuilder unitBuilder)
        {
            unitBuilder.BuildLife();
            unitBuilder.BuildMana();
            unitBuilder.BuildAttackPoints();
            unitBuilder.BuildDeffencePoints();
        }
    }

}
