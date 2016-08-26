namespace ConsoleForum.Commands
{
    using System.Linq;

    using ConsoleForum.Contracts;

    public class OpenQuestionCommand : AbstractCommand
    {
        public OpenQuestionCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            var questions = this.Forum.Questions;
            var targetId = int.Parse(this.Data[1]);
            var currentQuestion = questions.FirstOrDefault(q => q.Id == targetId);

            if (currentQuestion == null)
            {
                throw new CommandException(Messages.NoQuestion);
            }

            this.Forum.CurrentQuestion = currentQuestion;

            this.Forum.Output.AppendLine(currentQuestion.ToString());
        }
    }
}
