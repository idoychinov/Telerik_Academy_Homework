using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace StudentRegistrationForm
{
    public partial class Default : System.Web.UI.Page
    {
        public void ButtonSubmit_Click(object sender, EventArgs e)
        {
            var output = this.Output.Controls;

            var name =new HtmlGenericControl("h1");
            name.InnerText = Server.HtmlEncode(this.FirstName.Text) + " "+ Server.HtmlEncode(this.LastName.Text);
            var facultyNumber = new HtmlGenericControl("p");
            facultyNumber.InnerText = "Faculty number: "+Server.HtmlEncode(this.FacultyNumber.Text);
            var university = new HtmlGenericControl("p");
            university.InnerText = "University: "+Server.HtmlEncode(this.University.SelectedValue);
            var coursesHeader = new HtmlGenericControl("h3");
            coursesHeader.InnerText = "Selected Courses: ";
            var coursesList = new HtmlGenericControl("ul");
            foreach(ListItem item in this.Courses.Items)
            {
                if(item.Selected)
                {
                    var li = new HtmlGenericControl("li");
                    li.InnerText = item.Text;
                    coursesList.Controls.Add(li);
                }
            }

            output.Add(name);
            output.Add(facultyNumber);
            output.Add(university);
            output.Add(coursesHeader);
            output.Add(coursesList);

        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

    }
}