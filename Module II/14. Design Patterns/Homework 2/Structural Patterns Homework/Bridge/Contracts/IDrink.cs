using Bridge.Enums;

namespace Bridge.Contracts
{
    public interface IDrink : IJunkFood
    {
        DrinkType DrinkType { get; set; }
    }
}
