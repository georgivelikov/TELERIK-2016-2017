namespace Company.DataGenerator
{
    using System;

    public class RandomGenerator
    {
        private const string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        private static RandomGenerator instance;

        private readonly Random random;

        private RandomGenerator()
        {
            this.random = new Random();
        }

        public static RandomGenerator Instance
        {
            get
            {
                return instance ?? (instance = new RandomGenerator());
            }
        }

        public int GetRandomNumber(int min, int max)
        {
            return this.random.Next(min, max + 1);
        }

        public string GetRandomString(int length)
        {
            var chars = new char[length];

            for (int i = 0; i < length; i++)
            {
                chars[i] = Letters[this.GetRandomNumber(0, Letters.Length - 1)];
            }

            return new string(chars);
        }

        public DateTime GetRandomDate()
        {
            var year = this.GetRandomNumber(1990, 2016);
            var month = this.GetRandomNumber(1, 12);
            int day;

            if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
            {
                day = this.GetRandomNumber(1, 31);
            }
            else if (month == 4 || month == 6 || month == 9 || month == 11)
            {
                day = this.GetRandomNumber(1, 30);
            }
            else
            {
                if (DateTime.IsLeapYear(year))
                {
                    day = this.GetRandomNumber(1, 29);
                }
                else
                {
                    day = this.GetRandomNumber(1, 28);
                }
            }

            var hour = this.GetRandomNumber(0, 23);
            var minute = this.GetRandomNumber(0, 59);
            var sec = this.GetRandomNumber(0, 59);


            return new DateTime(year, month, day, hour, minute, sec);
        }
    }
}
