namespace ChatDatabase
{
    using System;
    using System.Linq;
    using MongoDB.Driver;

    using Model;
    using MongoDB.Driver.Builders;

    public class ChatDatabaseRepository
    {
        private const string DefaultServerPath = "mongodb://localhost";
        private const string DefaultDatabase = "ChatDb";
        private const string MessagesCollection = "Messages";
        private const string UsersCollection = "Users";


        private MongoClient client;
        private MongoServer server;
        private MongoDatabase db;



        public ChatDatabaseRepository()
            : this(null, null)
        {
        }

        public ChatDatabaseRepository(string serverPath, string databaseName)
        {
            if (serverPath == null || serverPath == string.Empty)
            {
                this.client = new MongoClient(DefaultServerPath);
            }
            else
            {
                this.client = new MongoClient(serverPath);
            }

            this.server = this.client.GetServer();

            if (databaseName == null || databaseName == string.Empty)
            {
                this.db = server.GetDatabase(DefaultDatabase);
            }
            else
            {
                this.db = server.GetDatabase(databaseName);
            }


            this.Users.EnsureIndex(new IndexKeysBuilder().Ascending("UserName"), IndexOptions.SetUnique(true));

        }
        
        public MongoCollection<Message> Messages
        {
            get
            {
                return this.db.GetCollection<Message>(MessagesCollection);
            }
        }

        public MongoCollection<User> Users
        {
            get
            {
                return this.db.GetCollection<User>(UsersCollection);
            }
        }
    }
}
