namespace Bridge.Contracts
{
    public interface IJunkFood
    {
        decimal BasePrice { get; set; }

        decimal TotalPrice();
    }
}
