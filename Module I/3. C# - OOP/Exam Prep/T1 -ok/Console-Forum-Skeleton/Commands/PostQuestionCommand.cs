namespace ConsoleForum.Commands
{
    using System;

    using ConsoleForum.Contracts;
    using ConsoleForum.Entities.Posts;
    using ConsoleForum.Entities.Users;

    public class PostQuestionCommand : AbstractCommand
    {
        public PostQuestionCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            if (!this.Forum.IsLogged)
            {
                throw new CommandException(Messages.NotLogged);
            }

            var title = this.Data[1];
            var body = this.Data[2];
            var user = this.Forum.CurrentUser;
            var newUser = new User(user.Id, user.Username, user.Password, user.Email);
            
            var question = new Question(this.Forum.Questions.Count + 1, title, body, newUser);
            this.Forum.Questions.Add(question);

            this.Forum.Output.AppendLine(string.Format(Messages.PostQuestionSuccess, question.Id));
        }
    }
}
