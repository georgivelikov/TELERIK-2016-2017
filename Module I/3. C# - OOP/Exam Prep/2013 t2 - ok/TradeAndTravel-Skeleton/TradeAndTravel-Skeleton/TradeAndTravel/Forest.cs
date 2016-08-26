namespace TradeAndTravel
{
    public class Forest : Location, IGatheringLocation
    {
        private readonly ItemType gatheredType;
        private readonly ItemType requiredItem;

        public Forest(string name)
            : base(name, LocationType.Forest)
        {
            this.gatheredType = ItemType.Wood;
            this.requiredItem = ItemType.Weapon;
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
            return new Wood(name);
        }
    }
}