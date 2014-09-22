using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class Like
    {
        public int Id { get; set; }

        public string AuthorId { get; set; }

        public virtual ForumUser Author { get; set; }

        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }
    }
}
