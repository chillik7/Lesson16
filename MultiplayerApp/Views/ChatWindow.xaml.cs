using System.Windows;

namespace MultiplayerApp.Views
{
    public partial class ChatWindow : Window
    {
        public ChatWindow()
        {
            InitializeComponent();
            ChatService.StartListening(ReceiveMessage);
        }

        private void OnSendMessageClick(object sender, RoutedEventArgs e)
        {
            var message = MessageTextBox.Text;
            ChatService.SendMessage(message);
            MessageTextBox.Clear();
        }
        private void ReceiveMessage(string message)
        {
            Dispatcher.Invoke(() => MessagesListBox.Items.Add(message));
        }
    }
}
