using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RandomNumbers
{
    public partial class Default : System.Web.UI.Page
    {
        private static Random rand = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void ButtonSubmitHtmlControl_Click(object sender, EventArgs e)
        {
            this.ResultHtmlControl.InnerText =
                GenerateRandomNumber(int.Parse(this.FirstNumberHtmlControl.Value), int.Parse(this.SecondNumberHtmlControl.Value));

        }

        public void ButtonSubmitWebControl_Click(object sender, EventArgs e)
        {
            
            this.ResultWebControl.Text =
                GenerateRandomNumber(int.Parse(this.FirstNumberWebControl.Text), int.Parse(this.SecondNumberWebControl.Text));
        }

        public string GenerateRandomNumber(int first, int second)
        {
            var generatedNumber = rand.Next(Math.Min(first, second), Math.Max(first, second) + 1);
            return generatedNumber.ToString();
        }
    }
}