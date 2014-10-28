using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebChat.Models;

namespace WebChat.Posts
{
    public partial class All : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<WebChat.Models.Message> ListView_GetData()
        {
            var context = new ApplicationDbContext();
            return context.Messages
                .Include(m=>m.Author)
                .OrderByDescending(m => m.CreationDate);
        }
    }
}