namespace ChatConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ChatDatabase;
    using ChatDatabase.Model;
    using MongoDB.Driver;
    using MongoDB.Driver.Linq;


    class ChatConsoleClient
    {
        private static ChatDatabaseRepository db;
        static void Main()
        {
            db = new ChatDatabaseRepository();
            User user;
            Console.WriteLine("Please enter non empty user name:");
            var userName = Console.ReadLine();
            user = new User(userName);
            try
            {
                db.Users.Insert<User>(user);
            }
            catch (MongoDuplicateKeyException)
            {
                Console.WriteLine("User name already exists on the server. Logging you as {0}.", userName);
                user = db.Users.AsQueryable<User>().Single(x => x.UserName == userName);
            }

            var sessionStart = DateTime.Now;
            var active = true;
            while (active)
            {
                Console.WriteLine("\nMenu:\n1 - Post Message\n2 - View all posts in this session\n3 - View all posts\nESC - Exit");
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        EnterMessage(user);
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        var sessionMessages = db.Messages.FindAll().Where(x => x.DateTime.ToLocalTime() >= sessionStart).AsEnumerable<Message>();
                        Console.WriteLine("All messages from current session");
                        WriteMessagesCollection(sessionMessages);
                        break;
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        var allMessages = db.Messages.FindAll().AsEnumerable<Message>();
                        Console.WriteLine("All messages in the chat database");
                        WriteMessagesCollection(allMessages);
                        break;
                    case ConsoleKey.Escape:
                        active = false;
                        Console.WriteLine("Thanks for using the Chat client. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Wrong command. Please try again");
                        break;
                }
            }
        }

        private static void EnterMessage(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("Message must have a user");
            }
            string text;
            bool isIncorrect = true;
            do
            {
                Console.WriteLine("Enter message text:");
                text = Console.ReadLine();
                isIncorrect = text == null || text == string.Empty;
                if (isIncorrect)
                {
                    Console.WriteLine("Message text must be at least one character");
                }
            } while (isIncorrect);

            var message = new Message(text, DateTime.Now, user);
            db.Messages.Insert<Message>(message);
        }

        private static void WriteMessagesCollection(IEnumerable<Message> collection)
        {
            foreach (var message in collection)
            {
                Console.WriteLine("{0:dd/MM/yyyy HH:mm:ss} - {1} said: {2}", message.DateTime.ToLocalTime(), message.User.UserName, message.Text);
            }
        }
    }
}
