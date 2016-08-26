namespace Infestation
{
    using Infestation.Suplements;
    using Infestation.Units;

    public class ExtendedHoldingPen : HoldingPen
    {
        protected override void ExecuteAddSupplementCommand(string[] commandWords)
        {
            var typeOfSupplement = commandWords[1];
            var targetId = commandWords[2];
            var targetUnit = this.GetUnit(targetId);
            if (targetUnit != null)
            {
                if (typeOfSupplement == "Weapon")
                {

                    targetUnit.AddSupplement(new Weapon());

                }
                else if (typeOfSupplement == "PowerCatalyst")
                {
                    targetUnit.AddSupplement(new PowerCatalyst());
                }
                else if (typeOfSupplement == "HealthCatalyst")
                {
                    targetUnit.AddSupplement(new HealthCatalyst());
                }
                else if (typeOfSupplement == "AggressionCatalyst")
                {
                    targetUnit.AddSupplement(new AggressionCatalyst());
                }
            }
        }

        protected override void ExecuteInsertUnitCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "Tank":
                    var tank = new Tank(commandWords[2]);
                    this.InsertUnit(tank);
                    break;
                case "Marine":
                    var marine = new Marine(commandWords[2]);
                    this.InsertUnit(marine);
                    break;
                case "Parasite":
                    var parasite = new Parasite(commandWords[2]);
                    this.InsertUnit(parasite);
                    break;
                case "Queen":
                    var queen = new Queen(commandWords[2]);
                    this.InsertUnit(queen);
                    break;
                default:
                    base.ExecuteInsertUnitCommand(commandWords);
                    break;
            }
        }

        protected override void ProcessSingleInteraction(Interaction interaction)
        {
            switch (interaction.InteractionType)
            {
                case InteractionType.Infest:
                    Unit sourseUnit = this.GetUnit(interaction.SourceUnit);
                    Unit targetUnit = this.GetUnit(interaction.TargetUnit);

                    if (InfestationRequirements.RequiredClassificationToInfest(targetUnit.UnitClassification)
                        == sourseUnit.UnitClassification)
                    {
                        targetUnit.AddSupplement(new InfestationSpores());
                    }
                    break;
                default:
                    base.ProcessSingleInteraction(interaction);
                    break;
            }
        }

        public override string ToString()
        {
            return base.ToString().Trim();
        }
    }
}
