namespace Builder
{
    using Builder.Builders;
    using Builder.Directors;

    public class StartUp
    {
        public static void Main()
        {
            IUnitConstructor constructor = new UnitConstructor();

            // And we can choose concrete builder
            UnitBuilder builder = new SoldierBuilder();
            constructor.Construct(builder);
            builder.Unit.Print();

            builder = new KnightBuilder();
            constructor.Construct(builder);
            builder.Unit.Print();

            builder = new MageBuilder();
            constructor.Construct(builder);
            builder.Unit.Print();
        }
    }
}
