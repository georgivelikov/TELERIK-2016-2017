namespace MusicShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using MusicShopManager.Interfaces;
    using MusicShopManager.Models;

    public class AcousticGuitar : Guitar, IAcousticGuitar
    {
        public AcousticGuitar(string make, string model, decimal price, string color, bool isElectronic, string bodyWood, string fingerboardWood, bool caseIncluded, StringMaterial stringMaterial)
            : base(make, model, price, color, isElectronic, bodyWood, fingerboardWood)
        {
            this.CaseIncluded = caseIncluded;
            this.StringMaterial = stringMaterial;
        }

        public bool CaseIncluded { get; set; }

        public StringMaterial StringMaterial { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendFormat("Case included: {0}\n", this.CaseIncluded ? "yes" : "no");
            sb.AppendFormat("String material: {0}\n", this.StringMaterial);

            return sb.ToString().Trim();
        }
    }
}
