namespace MusicShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using MusicShopManager.Interfaces;

    public class BaseGuitar : Guitar, IBassGuitar
    {
        private const int DefaultBaseGuitarStrings = 4;

        public BaseGuitar(string make, string model, decimal price, string color, bool isElectronic, string bodyWood, string fingerboardWood)
            : base(make, model, price, color, isElectronic, bodyWood, fingerboardWood)
        {
        }

        public override int NumberOfStrings
        {
            get
            {
                return BaseGuitar.DefaultBaseGuitarStrings;
            }
        }

        
    }
}
