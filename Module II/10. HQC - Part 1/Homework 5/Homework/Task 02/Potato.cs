using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02
{
    public class Potato
    {
        private bool isPeeled;

        private bool isRotten;

        public Potato()
        {
            this.isPeeled = false;
            this.isRotten = false;
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

        public bool IsRotten
        {
            get
            {
                return this.isRotten;
            }
            set
            {
                this.isRotten = value;
            }
        }
    }
}
