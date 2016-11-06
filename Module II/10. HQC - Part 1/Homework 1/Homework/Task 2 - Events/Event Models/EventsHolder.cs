using System;

using Wintellect.PowerCollections;

namespace Task_2___Events
{
    public class EventsHolder
    {
        private MultiDictionary<string, Event> eventsByTitle;
        private OrderedBag<Event> eventsByDate;
        private IMessageLogger messageLogger;

        public EventsHolder()
        {
            this.eventsByTitle = new MultiDictionary<string, Event>(true);
            this.eventsByDate = new OrderedBag<Event>();
            this.messageLogger = new MessageLogger();
        }

        public void AddEvent(DateTime date, string title, string location)
        {
            Event newEvent = new Event(date, title, location);
            this.eventsByTitle.Add(title.ToLower(), newEvent);
            this.eventsByDate.Add(newEvent);
            this.messageLogger.EventAdded();
        }

        public void DeleteEvents(string titleToDelete)
        {
            string searchedTitle = titleToDelete.ToLower();
            int deletedEventsCount = 0;
            foreach (var eventToRemove in this.eventsByTitle[searchedTitle])
            {
                deletedEventsCount++;
                this.eventsByDate.Remove(eventToRemove);
            }

            this.eventsByTitle.Remove(searchedTitle);

            if (deletedEventsCount == 0)
            {
                this.messageLogger.NoEventsFound();
            }
            else
            {
                this.messageLogger.EventsDeleted(deletedEventsCount);
            }
        }

        public void ListEvents(DateTime date, int count)
        {
            OrderedBag<Event>.View eventsToShow = this.eventsByDate.RangeFrom(new Event(date, string.Empty, string.Empty), true);

            int eventsShowed = 0;

            foreach (var eventToShow in eventsToShow)
            {
                if (eventsShowed == count)
                {
                    break;
                }

                this.messageLogger.PrintEvent(eventToShow);

                eventsShowed++;
            }

            if (eventsShowed == 0)
            {
                this.messageLogger.NoEventsFound();
            }
        }

        public void AlertInvalidCommand()
        {
            this.messageLogger.InvalidCommand();
        }

        public string ShowEventsHistory()
        {
            return this.messageLogger.Output;
        }
    }
}
