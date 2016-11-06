using System;
using System.Text;

public class Event : IComparable
{
    private const string DateFormat = "yyyy-MM-ddTHH:mm:ss";

    private DateTime date;

    private string title;

    private string location;

    public Event(DateTime date, string title, string location)
    {
        this.Date = date;
        this.Title = title;
        this.Location = location;
    }

    public DateTime Date
    {
        get
        {
            return this.date;
        }

        set
        {
            this.date = value;
        }
    }

    public string Title
    {
        get
        {
            return this.title;
        }

        set
        {
            this.title = value;
        }
    }

    public string Location
    {
        get
        {
            return this.location;
        }

        set
        {
            this.location = value;
        }
    }

    public int CompareTo(object obj)
    {
        Event other = obj as Event;

        int compareByDateResult = this.date.CompareTo(other.date);
        int compareByTitleResult = this.title.CompareTo(other.title);
        int compareByLocationResult = this.location.CompareTo(other.location);

        if (compareByDateResult == 0)
        {
            if (compareByTitleResult == 0)
            {
                return compareByLocationResult;
            }
            else
            {
                return compareByTitleResult;
            }
        }
        else
        {
            return compareByDateResult;
        }
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        
        stringBuilder.Append(this.date.ToString(DateFormat));

        stringBuilder.Append(" | " + this.title);

        if (!string.IsNullOrEmpty(this.location))
        {
            stringBuilder.Append(" | " + this.location);
        }

        return stringBuilder.ToString();
    }
}