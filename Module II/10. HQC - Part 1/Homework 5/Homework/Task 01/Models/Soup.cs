using Task_01.Contracts;

namespace Task_01.Models
{
   
    public class Soup : IMeal
    {
        private readonly double calories;

        private readonly string name;

        public Soup(double calories, string name)
        {
            this.calories = calories;
            this.name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public double Calories
        {
            get
            {
                return this.calories;
            }
        }

        public string CaloriesReport()
        {
            return string.Format("{0} has {1} calories.", this.Name, this.Calories);
        }
    }
}
