using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Task03
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterStudent(object sender, EventArgs e)
        {
            string firstName = Server.HtmlEncode(this.FirstName.Text);
            string lastName = Server.HtmlEncode(this.LastName.Text);
            string facNumber = Server.HtmlEncode(this.FacultyNumber.Text);

            string university = this.UniversityPicker.Text;
            string speciality = this.SpecialityPicker.Text;

            var courses = new List<string>();
            foreach (ListItem item in this.CoursePicker.Items)
            {
                if (item.Selected)
                {
                    courses.Add(item.ToString());
                }
            }

            StringBuilder sb = new StringBuilder();

            string row1 = $"<h2>{firstName} {lastName}</h2>";
            string row2 = $"<h3>f.n. {facNumber}</h3>";
            string row3 = $"University: <strong>{university}</strong> <br />";
            string row4 = $"Speciality: <strong>{speciality}</strong> <br />";
            string row5 = $"Courses: <strong>{string.Join(", ", courses)}</strong>";

            sb.AppendLine(row1);
            sb.AppendLine(row2);
            sb.AppendLine(row3);
            sb.AppendLine(row4);
            sb.AppendLine(row5);

            this.Result.Text = sb.ToString();

        }
    }
}