namespace Forum.Data
{
    using System;

    using Forum.Data.Repositories;
    using Forum.Models;

    public interface IForumData
    {
        IRepository<Article> Articles { get; }

        IRepository<Category> Categories { get; }

        IRepository<Like> Likes { get; }

        IRepository<Tag> Tags { get; }

        IRepository<Comment> Comments { get; }

        int SaveChanges();
    }
}
