using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestWebFormsApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int firstNumber, secondNumber;
            if (int.TryParse(this.TextBox1.Text, out firstNumber) && int.TryParse(this.TextBox2.Text, out secondNumber))
            {
                this.TextBox3.BackColor = System.Drawing.Color.White;
                this.TextBox3.Text = ((long)firstNumber + secondNumber).ToString();
            }
            else
            {
                this.TextBox3.BackColor = System.Drawing.Color.Red;
                this.TextBox3.Text = "One or both input parameters are not a numberes";
            }
        }
    }
}