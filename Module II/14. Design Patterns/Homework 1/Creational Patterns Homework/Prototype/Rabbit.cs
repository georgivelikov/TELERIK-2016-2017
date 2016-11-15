namespace Prototype
{
    public class Rabbit : RabbitPrototype
    {
        public Rabbit(string color)
        {
            this.Color = color;
        }

        public string Color { get; set; }

        public override Rabbit Multiply()
        {
            return this.MemberwiseClone() as Rabbit;
        }

        public override string ToString()
        {
            return $"I am {this.Color.ToLower()} rabbit";
        }
    }
}
