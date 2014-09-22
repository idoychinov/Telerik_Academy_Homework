namespace Forum.Data
{
    using System;

    using Forum.Data.Repositories;
    using Forum.Models;

    public class AlertsData : Data
    {
        public AlertsData(ForumDbContext context) 
            : base(context)
        {
        }

        public IRepository<Alert> Alerts
        {
            get { return this.GetRepository<Alert>(); }
        }
    }
}
