namespace MassEffect.Engine.Commands
{
    using System;
    using System.Linq;

    using MassEffect.GameObjects.Locations;
    using MassEffect.Interfaces;

    public class PlotJumpCommand : Command
    {
        public PlotJumpCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            var starship = this.GameEngine.Starships.FirstOrDefault(s => s.Name == commandArgs[1]);
            StarSystem destinationLocation = this.GameEngine.Galaxy.GetStarSystemByName(commandArgs[2]);
            string currentLocationName = starship.Location.Name;

            if (currentLocationName == destinationLocation.Name)
            {
                throw new Exception(string.Format(Messages.ShipAlreadyInStarSystem, destinationLocation.Name));
            }

            if (starship.Health <= 0)
            {
                throw new Exception(string.Format(Messages.ShipAlreadyDestroyed));
            }

            this.GameEngine.Galaxy.TravelTo(starship, destinationLocation);
            Console.WriteLine(Messages.ShipTraveled, starship.Name, currentLocationName, destinationLocation.Name);
        }
    }
}
