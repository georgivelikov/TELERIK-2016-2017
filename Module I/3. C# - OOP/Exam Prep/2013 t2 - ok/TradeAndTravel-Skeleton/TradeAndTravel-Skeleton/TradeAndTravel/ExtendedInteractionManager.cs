using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    public class ExtendedInteractionManager : InteractionManager
    {
        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                case "iron":
                    item = new Iron(itemNameString, itemLocation);
                    break;
                case "wood":
                    item = new Wood(itemNameString, itemLocation);
                    break;
                default:
                    item = base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
                    break;
            }

            return item;
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;
            switch (locationTypeString)
            {
                case "mine":
                    location = new Mine(locationName);
                    break;
                case "forest":
                    location = new Forest(locationName);
                    break;
                default:
                    location = base.CreateLocation(locationTypeString, locationName);
                    break;
            }
            return location;
        }

        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "gather":
                    this.HandleGatherInteraction(commandWords[2], actor);
                    break;
                case "craft":
                    this.HandleCraftInteraction(commandWords[2], commandWords[3], actor);
                    break;
                default:
                    base.HandlePersonCommand(commandWords, actor);
                    break;
            }
        }

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person = null;
            switch (personTypeString)
            {
                case "merchant":
                    person = new Merchant(personNameString, personLocation);
                    break;
                default:
                    person = base.CreatePerson(personTypeString, personNameString, personLocation);
                    break;
            }
            return person;
        }

        private void HandleCraftInteraction(string itemType, string itemName, Person actor)
        {
            if (itemType == "weapon")
            {
                bool hasWood = false;
                bool hasIron = false;

                foreach (var item in actor.ListInventory())
                {
                    if (item.GetType().Name == "Wood")
                    {
                        hasWood = true;
                    }

                    if (item.GetType().Name == "Iron")
                    {
                        hasIron = true;
                    }
                }

                if (hasIron && hasWood)
                {
                    var newItem = new Weapon(itemName);
                    this.AddToPerson(actor, newItem);
                }
            }
            else if (itemType == "armor")
            {
                bool hasIron = false;

                foreach (var item in actor.ListInventory())
                {
                    if (item.GetType().Name == "Iron")
                    {
                        hasIron = true;
                    }
                }

                if (hasIron)
                {
                    var newItem = new Armor(itemName);
                    this.AddToPerson(actor, newItem);
                }
            }
        }

        private void HandleGatherInteraction(string itemName, Person actor)
        {
            if (actor.Location.LocationType == LocationType.Mine)
            {
                bool neededItemFound = false;
                foreach (var item in actor.ListInventory())
                {
                    if (item.GetType().Name == "Armor")
                    {
                        neededItemFound = true;
                        break;
                    }
                }

                if (neededItemFound)
                {
                    var currentActorLocation = (Mine)actor.Location;
                    var newItem = currentActorLocation.ProduceItem(itemName);
                    this.AddToPerson(actor, newItem);
                }
            }
            else if (actor.Location.LocationType == LocationType.Forest)
            {
                bool neededItemFound = false;
                foreach (var item in actor.ListInventory())
                {
                    if (item.GetType().Name == "Weapon")
                    {
                        neededItemFound = true;
                        break;
                    }
                }

                if (neededItemFound)
                {
                    var currentActorLocation = (Forest)actor.Location;
                    var newItem = currentActorLocation.ProduceItem(itemName);
                    this.AddToPerson(actor, newItem);
                }
            }
        }
    }
}
