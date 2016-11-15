using Builder.Builders;

namespace Builder.Directors
{
    public interface IUnitConstructor
    {
        void Construct(UnitBuilder unitBuilder);
    }
}
