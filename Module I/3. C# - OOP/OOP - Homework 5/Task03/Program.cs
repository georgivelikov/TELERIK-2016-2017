namespace Task03
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main()
        {
            int numberStart = 0;
            int numberEnd = 100;
            int number = 900;
            try
            {
                if (number < numberStart || number > numberEnd)
                {
                    throw new InvalidRangeException<int>(string.Format("Number must be in range [{0} - {1}]", numberStart, numberEnd));
                }
            }
            catch (InvalidRangeException<int> ex1)
            {
                Console.WriteLine(ex1.Message);
            }

            DateTime dateStart = new DateTime(1980, 1, 1);
            DateTime dateEnd = new DateTime(2013, 12, 31);
            DateTime date = new DateTime(2016, 6, 24);

            try
            {
                if (date < dateStart || date > dateEnd)
                {
                    throw new InvalidRangeException<DateTime>(string.Format("Date must be in range [{0} - {1}]", dateStart.ToShortDateString(), dateEnd.ToShortDateString()));
                }
            }
            catch (InvalidRangeException<DateTime> ex2)
            {
                Console.WriteLine(ex2.Message);
            }
        }
    }
}
