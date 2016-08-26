namespace WinterIsComing.Core
{
    using WinterIsComing.Core.Commands;

    public class ExtendedCommandDispatcher : CommandDispatcher
    {
        public override void SeedCommands()
        {
            base.SeedCommands();
            this.commandsByName["toggle-effector"] = new ToggleEffectorCommand(this.Engine);
        }
    }
}
