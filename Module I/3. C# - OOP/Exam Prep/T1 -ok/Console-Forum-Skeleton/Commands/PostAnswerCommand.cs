namespace ConsoleForum.Commands
{
    using System;

    using ConsoleForum.Contracts;
    using ConsoleForum.Entities.Posts;
    using ConsoleForum.Entities.Users;

    public class PostAnswerCommand : AbstractCommand
    {
        public PostAnswerCommand(IForum forum)
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

	        var user = this.Forum.CurrentUser;
            var newUser = new User(user.Id, user.Username, user.Password, user.Email);

            var currentAnswer = new Answer(this.Forum.Answers.Count + 1, this.Data[1], newUser);
            this.Forum.CurrentQuestion.Answers.Add(currentAnswer);
            this.Forum.Answers.Add(currentAnswer);
            this.Forum.Output.AppendLine(string.Format(Messages.PostAnswerSuccess, currentAnswer.Id));
        }
    }
}
