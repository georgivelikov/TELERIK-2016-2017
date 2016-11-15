using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State.States
{
    public class Master : Position
    {
        public Master(Developer developer)
            : base(developer)
        {
        }

        public override void DrinkAlcohol()
        {
            base.DrinkAlcohol();
            if (this.Skill < 600)
            {
                this.Developer.Position = new Senior(this.Developer);
            }
        }

        public override string DoJob()
        {
            return "I am master and I do excellent job";
        }
    }
}
