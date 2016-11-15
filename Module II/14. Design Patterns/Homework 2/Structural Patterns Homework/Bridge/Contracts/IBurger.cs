using Bridge.Enums;

namespace Bridge.Contracts
{
    public interface IBurger : IJunkFood
    {
        BurgerType BurgerType { get; set; }
    }
}
