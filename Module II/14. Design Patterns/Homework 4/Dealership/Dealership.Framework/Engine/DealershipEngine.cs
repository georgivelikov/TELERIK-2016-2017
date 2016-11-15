using System;
using System.Collections.Generic;
using System.Text;

using Dealership.Contracts;
using Dealership.Framework.Engine;
using Dealership.Framework.Factories;
using Dealership.Framework.UserService;

namespace Dealership.Engine
{
    public sealed class DealershipEngine : IEngine
    {
        private IInputOutputProvider inputOutputProvider;

        private ICommandFactory commandFactory;

        private ICommandProcessor startingCommandProcessor;

        private IUserService userService;

        public DealershipEngine(IUserService userService, ICommandFactory commandFactory, IInputOutputProvider inputOutputProvider, ICommandProcessor commandProcessor)
        {
            this.commandFactory = commandFactory;
            this.inputOutputProvider = inputOutputProvider;
            this.startingCommandProcessor = commandProcessor;
            this.userService = userService;
        }

        public void Start()
        {
            var commands = this.ReadCommands();
            var commandResult = this.ProcessCommands(commands);
            this.PrintReports(commandResult);
        }

        public void Reset()
        {
            var commands = new List<ICommand>();
            var commandResult = new List<string>();
            this.PrintReports(commandResult);
        }


        private IList<ICommand> ReadCommands()
        {
            var commands = new List<ICommand>();

            var commandLine = this.inputOutputProvider.ReadLine();

            while (!string.IsNullOrEmpty(commandLine))
            {
                var currentCommand = this.commandFactory.CreateCommand(commandLine);
                commands.Add(currentCommand);

                commandLine = this.inputOutputProvider.ReadLine();
            }

            return commands;
        }

        private IList<string> ProcessCommands(IList<ICommand> commands)
        {
            var reports = new List<string>();

            foreach (var command in commands)
            {
                try
                {

                    var report = this.startingCommandProcessor.ProcessCommand(command, this.userService);
                    reports.Add(report);
                }
                catch (Exception ex)
                {
                    reports.Add(ex.Message);
                }
            }

            return reports;
        }

        private void PrintReports(IList<string> reports)
        {
            var output = new StringBuilder();

            foreach (var report in reports)
            {
                output.AppendLine(report);
                output.AppendLine(new string('#', 20));
            }

            this.inputOutputProvider.WriteLine(output.ToString());
        }
    }
}
