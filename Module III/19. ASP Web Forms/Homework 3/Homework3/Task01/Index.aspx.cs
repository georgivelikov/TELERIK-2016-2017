using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Task01
{
    public partial class Index : System.Web.UI.Page
    {
        private static Random randomGenerator = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void GenerateRandomNumberHTML(object sender, EventArgs e)
        {
            int minNumber = int.Parse(this.MinLimit.Value);
            int maxNumber = int.Parse(this.MaxLimit.Value);
            
            if(minNumber > maxNumber)
            {
                throw new ArgumentException("Min number should be less or equal to max number!");
            }

            int result = randomGenerator.Next(minNumber, maxNumber);

            this.Result.InnerText = result.ToString();
        }

        public void GenerateRandomNumberWEB(object sender, EventArgs e)
        {
            int minNumber = int.Parse(this.MinLimit2.Text);
            int maxNumber = int.Parse(this.MaxLimit2.Text);

            if (minNumber > maxNumber)
            {
                throw new ArgumentException("Min number should be less or equal to max number!");
            }

            int result = randomGenerator.Next(minNumber, maxNumber);

            this.Result2.Text = result.ToString();
        }
    }
}