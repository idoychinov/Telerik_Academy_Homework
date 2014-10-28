using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebChat.Models;

namespace WebChat.Messages
{
    public partial class Delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<WebChat.Models.Message> ListView_GetData()
        {
            var context = new ApplicationDbContext();
            return context.Messages
                .Include(m => m.Author)
                .OrderByDescending(m => m.CreationDate);
        }

        public void ListViewMessages_DeleteItem(int id)
        {
            var context = new ApplicationDbContext();
            var message = context.Messages.Find(id);
            context.Messages.Remove(message);
            context.SaveChanges();
        }
    }
}