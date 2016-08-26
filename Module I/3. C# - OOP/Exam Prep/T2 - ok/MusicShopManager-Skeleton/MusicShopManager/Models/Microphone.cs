namespace MusicShop.Models
{
    using System.Text;

    using MusicShopManager.Interfaces;

    public class Microphone : Article, IMicrophone
    {
        public Microphone(string make, string model, decimal price, bool hasCable)
            : base(make, model, price)
        {
            this.HasCable = hasCable;
        }

        public bool HasCable { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendFormat("Cable: {0}\n", this.HasCable ? "yes" : "no");

            return sb.ToString().Trim();
        }
    }
}
