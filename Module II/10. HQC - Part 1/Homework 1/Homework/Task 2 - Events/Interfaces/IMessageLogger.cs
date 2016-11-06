namespace Task_2___Events
{
    public interface IMessageLogger
    {
        string Output { get; }

        void EventAdded();

        void EventsDeleted(int deletedEventsCount);

        void NoEventsFound();

        void PrintEvent(Event eventToPrint);

        void InvalidCommand();
    }
}