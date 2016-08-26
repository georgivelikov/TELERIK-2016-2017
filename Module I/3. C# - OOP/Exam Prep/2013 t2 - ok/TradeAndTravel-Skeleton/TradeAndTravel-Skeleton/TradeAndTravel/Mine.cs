namespace TradeAndTravel
{
    public class Mine : Location, IGatheringLocation
    {
        private readonly ItemType gatheredType;
        private readonly ItemType requiredItem;

        public Mine(string name)
            : base(name, LocationType.Mine)
        {
            this.gatheredType = ItemType.Iron;
            this.requiredItem = ItemType.Armor;
        }

        public ItemType GatheredType
        {
            get
            {
                return this.gatheredType;
            }
        }

        public ItemType RequiredItem
        {
            get
            {
                return this.requiredItem;
            }
        }

        public Item ProduceItem(string name)
        {
            return new Iron(name);
        }
    }
}
