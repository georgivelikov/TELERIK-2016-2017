using Task_01.Contracts;

namespace Task_01.Models
{

    public abstract class Vegetable : IVegetable
    {
        private readonly double calories;

        private bool isPeeled;

        private bool isCut;

        public Vegetable(double calories)
        {
            this.calories = calories;
            this.isPeeled = false;
            this.isCut = false;
        }

        public double Calories
        {
            get
            {
                return this.calories;
            }
        }

        public bool IsPeeled
        {
            get
            {
                return this.isPeeled;
            }

            set
            {
                this.isPeeled = value;
            }
        }

        public bool IsCut
        {
            get
            {
                return this.isCut;
            }

            set
            {
                this.isCut = value;
            }
        }

    }
}
