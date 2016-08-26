using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleForum.Commands
{
    using ConsoleForum.Contracts;
    using ConsoleForum.Entities.Posts;

    public class MakeBestAnswerCommand : AbstractCommand
    {
        public MakeBestAnswerCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            if (!this.Forum.IsLogged)
            {
                throw new CommandException(Messages.NotLogged);
            }

            if (this.Forum.CurrentQuestion == null)
            {
                throw new CommandException(Messages.NoQuestionOpened);
            }

            var currentQuestion = this.Forum.CurrentQuestion;
            if (currentQuestion.Author.Id != this.Forum.CurrentUser.Id && this.Forum.CurrentUser.GetType().Name != "Administrator")
            {
                throw new CommandException(Messages.NoPermission);
            }

            var answer = currentQuestion.Answers.Select(a => a as Answer).FirstOrDefault(a => a.Id == int.Parse(this.Data[1]));

            if (answer == null)
            {
                throw new CommandException(Messages.NoAnswer);
            }

            var previousBestAnswer = currentQuestion.Answers.Select(a => a as Answer).FirstOrDefault(a => a.BestAnswer);
            if (previousBestAnswer != null)
            {
                previousBestAnswer.BestAnswer = false;
            }

            answer.BestAnswer = true;

            this.Forum.Output.AppendLine(string.Format(Messages.BestAnswerSuccess, answer.Id));
        }
    }
}
