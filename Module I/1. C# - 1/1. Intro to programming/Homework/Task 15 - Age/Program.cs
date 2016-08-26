using System;
using System.Globalization;

public class Program
{
    public static void Main()
    {
        DateTime currentDate = DateTime.Now;
        DateTime date = DateTime.ParseExact(Console.ReadLine(), "MM.dd.yyyy", CultureInfo.InvariantCulture);

        int yearDiff = 0;
        if (currentDate.Month < date.Month)
        {
            yearDiff = currentDate.Year - date.Year - 1;
        }
        else if (currentDate.Month == date.Month)
        {
            if (currentDate.Day < date.Day)
            {
                yearDiff = currentDate.Year - date.Year - 1;
            }
            else
            {
                yearDiff = currentDate.Year - date.Year;
            }
        }
        else
        {
            yearDiff = currentDate.Year - date.Year;
        }

        Console.WriteLine(yearDiff);
        Console.WriteLine(yearDiff + 10);
    }
}

