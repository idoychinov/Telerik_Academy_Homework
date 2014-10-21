using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TextEscaping
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void ButtonSubmit_Click(object sender, EventArgs e)
        {
            var encodedText =  Server.HtmlEncode(this.InputTextBox.Text);
            this.OutputLabel.Text = encodedText;
            this.OutputTextBox.Text = encodedText;
        }
    }
}