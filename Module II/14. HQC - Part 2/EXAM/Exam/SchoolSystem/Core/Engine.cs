using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using SchoolSystem.Contracts;

namespace SchoolSystem.Core
{
    public class Engine
    {
        private const string InvalidCommand = "The passed command is not found!";
        private const string EndCommand = "End";
        private IReader reader;
        private IWriter writer;
        private ISchoolSystemData data;

        public Engine(IReader readed, IWriter writer, ISchoolSystemData data)
        {
            this.reader = readed;
            this.writer = writer;
            this.data = data;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    var line = this.reader.ReadLine();
                    if (line == EndCommand)
                    {
                        break;
                    }

                    var commandName = line.Split(' ')[0];
                    var commandParams = line.Split(' ').ToList();
                    var command = this.CreateCommand(commandName);
                    commandParams.RemoveAt(0);

                    var commandResult = this.ExecuteCommand(command, commandParams, this.data);
                    this.writer.WriteLine(commandResult);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
            }
        }

        public ICommand CreateCommand(string commandName)
        {
            var assembly = this.GetType().GetTypeInfo().Assembly;
            var typeInfo =
                assembly.DefinedTypes.Where(
                    type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
                    .Where(type => type.Name.ToLower().Contains(commandName.ToLower()))
                    .FirstOrDefault();

            if (typeInfo == null)
            {
                throw new ArgumentException(InvalidCommand);
            }

            var command = Activator.CreateInstance(typeInfo) as ICommand;

            return command;
        }

        public string ExecuteCommand(ICommand command, IList<string> commandParams, ISchoolSystemData data)
        {
            return command.Execute(commandParams, data);
        }
    }
}
