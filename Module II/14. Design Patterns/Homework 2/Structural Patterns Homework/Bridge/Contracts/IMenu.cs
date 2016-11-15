namespace Bridge.Contracts
{
    public interface IMenu
    {
        IBurger Burger { get; set; }

        IDrink Drink { get; set; }

        decimal TotalPrice();
    }
}
