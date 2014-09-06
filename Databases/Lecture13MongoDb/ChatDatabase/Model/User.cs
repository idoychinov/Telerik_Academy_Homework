namespace ChatDatabase.Model
{
    using System;
    using MongoDB.Bson;

    public class User
    {
        private string userName;

        public User(string userName)
        {
            this.UserName = userName;
        }

        public string UserName
        {
            get
            {
                return this.userName;
            }

            set
            {
                if(value == string.Empty)
                {
                    throw new ArgumentException("UserName cannot be zero characters");
                }

                if(value == null)
                {
                    throw new ArgumentNullException("UserName cannot be null");
                }

                this.userName = value;
            }
        }

        public ObjectId id { get; set; }
     }
}
