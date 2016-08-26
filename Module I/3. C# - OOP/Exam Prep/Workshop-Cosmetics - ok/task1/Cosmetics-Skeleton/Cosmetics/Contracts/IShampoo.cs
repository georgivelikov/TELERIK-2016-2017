namespace Cosmetics.Contracts
{
    using Cosmetics.Common;

    public interface IShampoo : IProduct
    {
        UsageType Usage { get; }

        uint Milliliters { get; }
    }
}