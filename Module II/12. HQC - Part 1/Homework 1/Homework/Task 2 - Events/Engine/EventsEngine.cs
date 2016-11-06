using System;

using Task_2___Events.Interfaces;

namespace Task_2___Events.Engine
{
    public class EventsEngine
    {
        private const char CommandSeparator = '|';

        private EventsHolder eventsHolder;

        private IWriter writer;

        private IReader reader;

        private bool isEngineRunning;

        public EventsEngine(IWriter writer, IReader reader)
        {
            this.eventsHolder = new EventsHolder();
            this.writer = writer;
            this.reader = reader;
            this.isEngineRunning = true;
        }

        public void Run()
        {
            while (this.isEngineRunning)
            {
                this.ExecuteNextCommand();
            }
            string eventsHistory = this.eventsHolder.ShowEventsHistory();

            this.writer.WriteLine(eventsHistory.Trim());
        }

        private void ExecuteNextCommand()
        {
            string commandString = this.reader.ReadLine();
            string[] commandArgs = commandString.Split(CommandSeparator);
            string commandName = commandArgs[0];

            if (commandName == "AddEvent")
            {
                this.AddEvent(commandArgs);
            }
            else if (commandName == "DeleteEvent")
            {
                this.DeleteEvent(commandArgs);
            }
            else if (commandName == "ListEvents")
            {
                this.ListEvents(commandArgs);
            }
            else if (commandName == "Exit")
            {
                this.isEngineRunning = false;
            }
            else
            {
                this.eventsHolder.AlertInvalidCommand();
            }
        }

        private void AddEvent(string[] commandArgs)
        {
            DateTime date = DateTime.Parse(commandArgs[1].Trim());
            string title = commandArgs[2].Trim();
            string location = commandArgs[3].Trim();

            this.eventsHolder.AddEvent(date, title, location);
        }

        private void DeleteEvent(string[] commandArgs)
        {
            string titleToDelete = commandArgs[1].Trim();
            this.eventsHolder.DeleteEvents(titleToDelete);
        }

        private void ListEvents(string[] commandArgs)
        {
            DateTime date = DateTime.Parse(commandArgs[1].Trim());
            int count = int.Parse(commandArgs[2].Trim());

            this.eventsHolder.ListEvents(date, count);
        }
    }
}
