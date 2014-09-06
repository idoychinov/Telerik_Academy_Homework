using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using MongoDB.Driver;
using MongoDB.Driver.Linq;

using ChatDatabase;
using ChatDatabase.Model;

namespace ChatDesctopClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ChatDatabaseRepository db;
        private User currentUser;
        private DateTime sessionStart;

        public MainWindow()
        {
            InitializeComponent();
            db = new ChatDatabaseRepository();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var userName = userNameTextBox.Text;
            if (userName == string.Empty || userName == null)
            {
                MessageBox.Show("User name must be at least 1 character long", "Empty user name", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var user = new User(userName);
            try
            {
                db.Users.Insert<User>(user);
            }
            catch (MongoDuplicateKeyException)
            {
                MessageBox.Show(String.Format("User name already exists on the server. Logging you as {0}.", userName),
                    "User exists", MessageBoxButton.OK, MessageBoxImage.Information);
                user = db.Users.AsQueryable<User>().Single(x => x.UserName == userName);
            }
            this.currentUser = user;
            this.sessionStart = DateTime.Now;
            userNameTextBox.Visibility = Visibility.Hidden;
            loginButton.Visibility = Visibility.Hidden;
            messageText.Visibility = Visibility.Visible;
            sendMessage.Visibility = Visibility.Visible;
            viewSessionPosts.Visibility = Visibility.Visible;
            viewAllPosts.Visibility = Visibility.Visible;
            messagesList.Visibility = Visibility.Visible;
            messageListLabel.Visibility = Visibility.Visible;
            userNameLabel.Content += " " + userName;
            AllMessages();
        }

        private void SentMessage_Click(object sender, RoutedEventArgs e)
        {
            var text = messageText.Text;
            if (text == string.Empty || text == null)
            {
                MessageBox.Show("Message must be at least 1 character long", "Empty message", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var message = new Message(text, DateTime.Now, this.currentUser);
            db.Messages.Insert<Message>(message);

            AllMessages();
        }

        private void ViewSessionPosts_Click(object sender, RoutedEventArgs e)
        {
            var sessionMessages = db.Messages.FindAll().Where(x => x.DateTime.ToLocalTime() >= sessionStart).AsEnumerable<Message>();
            PopulateList(sessionMessages);
            messageListLabel.Content = "Session Posts";

        }
        private void AllMessages()
        {
            var allMessages = db.Messages.FindAll().AsEnumerable<Message>();
            PopulateList(allMessages);
            messageListLabel.Content = "All Posts";
        }

        private void ViewAllPosts_Click(object sender, RoutedEventArgs e)
        {
            AllMessages();
        }

        // No time to play around with bindings, so it's done the old fashioned way.
        private void PopulateList(IEnumerable<Message> collection)
        {
            messagesList.Items.Clear();

            foreach (var message in collection)
            {
                messagesList.Items.Add(String.Format("{0:dd/MM/yyyy HH:mm:ss} - {1} said: {2}", message.DateTime.ToLocalTime(), message.User.UserName, message.Text));
            }
        }
    }
}
