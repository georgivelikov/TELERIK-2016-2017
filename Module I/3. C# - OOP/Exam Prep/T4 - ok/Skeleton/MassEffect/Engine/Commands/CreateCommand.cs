namespace MassEffect.Engine.Commands
{
    using System;

    using MassEffect.GameObjects.Enhancements;
    using MassEffect.GameObjects.Locations;
    using MassEffect.GameObjects.Ships;
    using MassEffect.Interfaces;

    public class CreateCommand : Command
    {
        public CreateCommand(IGameEngine gameEngine) 
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            StarshipType type = this.GetStarshipType(commandArgs[1]);

            string name = commandArgs[2];
            if (this.GameEngine.Galaxy.ShipNames.Contains(name))
            {
                throw new Exception(Messages.DuplicateShipName);
            }

            this.GameEngine.Galaxy.ShipNames.Add(name);

            StarSystem location = this.GameEngine.Galaxy.GetStarSystemByName(commandArgs[3]);

            var starship = this.GameEngine.ShipFactory.CreateShip(type, name, location);

            if (commandArgs.Length > 4)
            {
                for (int i = 4; i < commandArgs.Length; i++)
                {
                    var enhancmentType = this.GetEnhancmentType(commandArgs[i]);
                    var enhancement = this.GameEngine.EnhancementFactory.Create(enhancmentType);
                    starship.AddEnhancement(enhancement);
                }
            }

            this.GameEngine.Starships.Add(starship);

            Console.WriteLine(Messages.CreatedShip, type, name);
        }

        private StarshipType GetStarshipType(string type)
        {
            if (type == "Frigate")
            {
                return StarshipType.Frigate;
            }
            else if (type == "Cruiser")
            {
                return StarshipType.Cruiser;
            }
            else
            {
                return StarshipType.Dreadnought;
            }
        }

        private EnhancementType GetEnhancmentType(string enhancementType)
        {
            if (enhancementType == "ThanixCannon")
            {
                return EnhancementType.ThanixCannon;
            }
            else if (enhancementType == "KineticBarrier")
            {
                return EnhancementType.KineticBarrier;
            }
            else
            {
                return EnhancementType.ExtendedFuelCells;
            }
        }
    }
}
