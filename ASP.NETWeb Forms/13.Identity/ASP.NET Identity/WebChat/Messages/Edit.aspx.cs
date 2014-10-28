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
    public partial class Edit : System.Web.UI.Page
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

        public void ListView_UpdateItem(int id)
        {
            var context = new ApplicationDbContext();
            var messageToUpdate = context.Messages.Include(m => m.Author).FirstOrDefault(m=>m.Id==id);
            if (messageToUpdate == null)
            {
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }

            TryUpdateModel(messageToUpdate);
            if (ModelState.IsValid)
            {
                context.SaveChanges();
            }
        }

        protected void ButtonEditMessage_Click(object sender, EventArgs e)
        {

        }
    }
}