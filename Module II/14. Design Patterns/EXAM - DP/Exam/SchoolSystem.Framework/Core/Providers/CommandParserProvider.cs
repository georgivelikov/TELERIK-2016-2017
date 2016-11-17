using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using SchoolSystem.Framework.Common;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Framework.Core.Providers
{
    public class CommandParserProvider : IParser
    {
        private ICommandFactory commandFactory;

        private IStudentFactory studentFactory;

        private ITeacherFactory teacherFactory;

        public CommandParserProvider(ICommandFactory commandFactory, IStudentFactory studentFactory, ITeacherFactory teacherFactory)
        {
            this.commandFactory = commandFactory;
            this.studentFactory = studentFactory;
            this.teacherFactory = teacherFactory;
        }

        public ICommand ParseCommand(string fullCommand)
        {
            var commandName = fullCommand.Split(' ')[0];
            var commandTypeInfo = this.FindCommand(commandName);
            var command = this.CreateCommand(commandTypeInfo);

            return command;
        }

        public IList<string> ParseParameters(string fullCommand)
        {
            var commandParts = fullCommand.Split(' ').ToList();
            commandParts.RemoveAt(0);

            if (commandParts.Count() == 0)
            {
                return null;
            }

            return commandParts;
        }

        private TypeInfo FindCommand(string commandName)
        {
            var currentAssembly = this.GetType().GetTypeInfo().Assembly;
            var commandTypeInfo = currentAssembly.DefinedTypes
                .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
                .Where(type => type.Name.ToLower().Contains(commandName.ToLower()))
                .SingleOrDefault();

            if (commandTypeInfo == null)
            {
                throw new ArgumentException("The passed command is not found!");
            }

            return commandTypeInfo;
        }

        private ICommand CreateCommand(TypeInfo commandTypeInfo)
        {
            if (commandTypeInfo.Name == Constants.CreateStudentCommandName)
            {
                return this.commandFactory.GetCreateStudentCommand(this.studentFactory);
            }
            else if (commandTypeInfo.Name == Constants.CreateTeacherCommandName)
            {
                return this.commandFactory.GetCreateTeacherCommand(this.teacherFactory);
            }
            else if (commandTypeInfo.Name == Constants.RemoveStudentCommandName)
            {
                return this.commandFactory.GetRemoveStudentCommand();
            }
            else if (commandTypeInfo.Name == Constants.RemoveTeacherCommandName)
            {
                return this.commandFactory.GetRemoveTeacherCommand();
            }
            else if (commandTypeInfo.Name == Constants.StudentListMarksCommandName)
            {
                return this.commandFactory.GetStudentListMarksCommand();
            }
            else if (commandTypeInfo.Name == Constants.TeacherAddMarkCommandName)
            {
                return this.commandFactory.GetTeacherAddMarkCommand();
            }
            else
            {
                throw new ArgumentException("The passed command is not found!");
            }
        }
    }
}
