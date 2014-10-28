using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebChat.Models;

namespace WebChat.Messages
{
    public partial class New : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonAddMessage_Click(object sender, EventArgs e)
        {
            var context = new ApplicationDbContext();
            string content = this.TextBoxContent.Text;
            var author = context.Users.Find(User.Identity.GetUserId());

            var newMessage = new Message()
            {
                Content = content,
                Author = author,
                CreationDate = DateTime.Now
            };

            context.Messages.Add(newMessage);
            context.SaveChanges();

            Response.Redirect("~/Messages/All");
        }
    }
}