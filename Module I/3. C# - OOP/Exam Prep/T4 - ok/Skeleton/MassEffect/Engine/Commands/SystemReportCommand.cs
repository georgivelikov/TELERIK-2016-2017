namespace MassEffect.Engine.Commands
{
    using System;
    using System.Linq;

    using MassEffect.Interfaces;

    public class SystemReportCommand : Command
    {
        public SystemReportCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            var systemName = commandArgs[1];

            var intactShips =
                this.GameEngine.Starships.Where(s => s.Location.Name == systemName && s.Health > 0)
                    .OrderByDescending(s => s.Health)
                    .ThenByDescending(s => s.Shields)
                    .ToList();
            var destroyedShips =
                this.GameEngine.Starships.Where(s => s.Location.Name == systemName && s.Health <= 0)
                    .OrderBy(s => s.Name)
                    .ToList();

            Console.WriteLine("Intact ships:");
            if (intactShips.Count == 0)
            {
                Console.WriteLine("N/A");
            }
            else
            {
                foreach (var ship in intactShips)
                {
                    Console.WriteLine(ship);
                }
            }

            Console.WriteLine("Destroyed ships:");
            if (destroyedShips.Count == 0)
            {
                Console.WriteLine("N/A");
            }
            else
            {
                foreach (var ship in destroyedShips)
                {
                    Console.WriteLine(ship);
                }
            }

        }
    }
}
