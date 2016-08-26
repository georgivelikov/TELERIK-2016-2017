namespace MassEffect.Engine.Commands
{
    using System;
    using System.Linq;

    using MassEffect.Interfaces;

    public class AttackCommand : Command
    {
        public AttackCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            var attackingShip = this.GameEngine.Starships.FirstOrDefault(s => s.Name == commandArgs[1]);
            var deffendingShip = this.GameEngine.Starships.FirstOrDefault(s => s.Name == commandArgs[2]);
            
            this.Validate(attackingShip, deffendingShip);

            var projectile = attackingShip.ProduceAttack();
            deffendingShip.RespondToAttack(projectile);

            Console.WriteLine(Messages.ShipAttacked, attackingShip.Name, deffendingShip.Name);
            if (deffendingShip.Health <= 0)
            {
                Console.WriteLine(Messages.ShipDestroyed, deffendingShip.Name);
            }
        }

        private void Validate(IStarship attackingShip, IStarship deffendingShip)
        {
            if (attackingShip.Location != deffendingShip.Location)
            {
                throw new Exception(Messages.NoSuchShipInStarSystem);
            }

            if (attackingShip.Health <= 0)
            {
                throw new Exception(Messages.ShipAlreadyDestroyed);
            }

            if (deffendingShip.Health <= 0)
            {
                throw new Exception(Messages.ShipAlreadyDestroyed);
            }
        }
    }
}
