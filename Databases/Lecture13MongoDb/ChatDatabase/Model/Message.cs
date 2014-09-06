namespace ChatDatabase.Model
{
    using System;
    using MongoDB.Bson;

    public class Message
    {
        private string text;
        
        public Message(string text, DateTime date, User user)
        {
            this.Text = text;

            if(date == null)
            {
                throw new ArgumentNullException("Date cannot be null");
            }

            this.DateTime = date;

            if(user == null)
            {
                throw new ArgumentNullException("User cannot be null");
            }

            this.User = user;
        }

        public string Text
        {
            get
            {
                return this.text;
            }

            set
            {
                if(value == string.Empty)
                {
                    throw new ArgumentException("Text cannot be zero characters");
                }

                if(value == null)
                {
                    throw new ArgumentNullException("Text cannot be null");
                }

                this.text = value;
            }
        }

        public DateTime DateTime { get; private set; }

        public User User { get; private set; }

        public ObjectId Id {get; set;}
    }
}
