using System;
using System.Globalization;

namespace WebFormsCalculator
{
    public partial class Calculator : System.Web.UI.Page
    {
        protected void CalculateSum(object sender, EventArgs e)
        {
            try
            {
                var firstNum = decimal.Parse(this.FirstNumber.Text);
                var secondNum = decimal.Parse(this.SecondNumber.Text);
                var sum = firstNum + secondNum;
                this.Result.Text = sum.ToString(CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                this.Result.Text = "Invalid.";
            }
        }
    }
}