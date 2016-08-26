namespace TradeAndTravel
{
    using System.Collections.Generic;

    public class Wood : Item
    {
        private const int GeneralWoodValue = 2;

        public Wood(string name, Location location = null)
            : base(name, Wood.GeneralWoodValue, ItemType.Wood, location)
        {
        }

        public static List<ItemType> GetComposingItems()
        {
            return new List<ItemType>() { };
        }

        public override void UpdateWithInteraction(string interaction)
        {
            if (interaction == "drop")
            {
                if (this.Value > 0)
                {
                    this.Value--;
                }
            }
        }
    }
}