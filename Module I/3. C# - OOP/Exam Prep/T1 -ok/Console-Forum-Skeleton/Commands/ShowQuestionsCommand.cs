namespace ConsoleForum.Commands
{
    using System.Linq;

    using ConsoleForum.Contracts;

    public class ShowQuestionsCommand : AbstractCommand
    {
        public ShowQuestionsCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            var questions = this.Forum.Questions;
            this.Forum.CurrentQuestion = null;
            if (questions.Count == 0)
            {
                throw new CommandException(Messages.NoQuestions);
            }
            else
            {
                var sortedQuestions = questions.OrderBy(question => question.Id);
                foreach (var q in sortedQuestions)
                {
                    this.Forum.Output.AppendLine(q.ToString());
                }
            }
        }
    }
}
