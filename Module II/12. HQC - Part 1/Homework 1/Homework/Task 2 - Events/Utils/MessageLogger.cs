namespace Task_2___Events
{
    using System.Text;

    public class MessageLogger : IMessageLogger
    {
        private StringBuilder output;

        public MessageLogger()
        {
            this.output = new StringBuilder();
        }

        public string Output
        {
            get
            {
                return this.output.ToString();
            }
        }

        public void EventAdded()
        {
            this.output.Append("Event added\n");
        }

        public void EventsDeleted(int deletedEventsCount)
        {
            this.output.AppendFormat("{0} events deleted\n", deletedEventsCount);
        }

        public void NoEventsFound()
        {
            this.output.Append("No events found\n");
        }

        public void InvalidCommand()
        {
            this.output.Append("Invalid command\n");
        }

        public void PrintEvent(Event eventToPrint)
        {
            if (eventToPrint != null)
            {
                this.output.Append(eventToPrint + "\n");
            }
        }
    }
}
