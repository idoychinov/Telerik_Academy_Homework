using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleWebFormApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        
            this.hello.Text = "Hello,ASP.NET";
            this.assemby.Text = Assembly.GetExecutingAssembly().Location;
        }
    }
}