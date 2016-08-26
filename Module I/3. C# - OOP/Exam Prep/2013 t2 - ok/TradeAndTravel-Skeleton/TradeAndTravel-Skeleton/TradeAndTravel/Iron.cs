namespace TradeAndTravel
{
    using System.Collections.Generic;

    public class Iron : Item
    {
        private const int GeneralIronValue = 3;

        public Iron(string name, Location location = null)
            : base(name, Iron.GeneralIronValue, ItemType.Iron, location)
        {
        }

        public static List<ItemType> GetComposingItems()
        {
            return new List<ItemType>() { };
        }
    }
}

