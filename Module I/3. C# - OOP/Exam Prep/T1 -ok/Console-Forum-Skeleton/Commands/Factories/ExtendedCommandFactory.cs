namespace ConsoleForum.Commands
{
    using System;
    using System.Linq;
    using System.Reflection;

    using ConsoleForum.Contracts;

    public static class ExtendedCommandFactory
    {
        public static IExecutable Create(string commandInput, IForum forum)
        {
            var data = commandInput.Split(null);
            string commandName = data[0].ToLower();

            AbstractCommand command = null;

            switch (commandName)
            {
                case "register": command = new RegisterCommand(forum);
                    break;
                case "login":
                    command = new LoginCommand(forum);
                    break;
                case "logout":
                    command = new LogoutCommand(forum);
                    break;
                case "showquestions":
                    command = new ShowQuestionsCommand(forum);
                    break;
                case "openquestion":
                    command = new OpenQuestionCommand(forum);
                    break;
                case "postquestion":
                    command = new PostQuestionCommand(forum);
                    break;
                case "postanswer":
                    command = new PostAnswerCommand(forum);
                    break;
            }

            foreach (var field in data)
            {
                command.Data.Add(field);
            }

            return (IExecutable)command;
        }
    }
}
