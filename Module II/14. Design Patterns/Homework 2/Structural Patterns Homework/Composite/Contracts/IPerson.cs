namespace Composite.Contracts
{
    public interface IPerson
    {
        string Name { get; }

        void Display(int depth);
    }
}
