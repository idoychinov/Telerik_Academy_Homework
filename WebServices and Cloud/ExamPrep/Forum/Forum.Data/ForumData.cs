namespace Forum.Data
{
    using System;

    using Forum.Models;
    using Forum.Data.Repositories;

    public class ForumData : Data, IForumData
    {
        public ForumData (ForumDbContext context)
            :base(context)
        {
        }

        public IRepository<Article> Articles
        {
            get { return this.GetRepository<Article>(); }
        }

        public IRepository<Category> Categories
        {
            get { return this.GetRepository<Category>(); }
        }

        public IRepository<Like> Likes
        {
            get { return this.GetRepository<Like>(); }
        }

        public IRepository<Tag> Tags
        {
            get { return this.GetRepository<Tag>(); }
        }

        public IRepository<Comment> Comments
        {
            get { return this.GetRepository<Comment>(); }
        }
    }
}
