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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void OnButtonClick(object sender, EventArgs e)
        {
            var name = this.NameInput.Text;
            this.NameInput.Text = string.Empty;
            this.Result.Text = "Hello " + name;
        }
    }
}