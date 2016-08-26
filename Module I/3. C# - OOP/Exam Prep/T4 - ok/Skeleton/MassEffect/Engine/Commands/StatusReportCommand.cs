namespace MassEffect.Engine.Commands
{
    using System;
    using System.Linq;

    using MassEffect.Interfaces;

    public class StatusReportCommand : Command
    {
        public StatusReportCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            var starship = this.GameEngine.Starships.FirstOrDefault(s => s.Name == commandArgs[1]);
            Console.WriteLine(starship);
        }
    }
}
