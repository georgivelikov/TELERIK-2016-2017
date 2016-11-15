namespace Composite.Contracts
{
    public interface IMinister : IPerson
    {
        void AddSubordinate(IPerson subordinate);
    }
}
