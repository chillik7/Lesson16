using System.Windows;

namespace MultiplayerApp.Views
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
        private void OnLoginClick(object sender, RoutedEventArgs e)
        {
            var username = UsernameTextBox.Text;
            var password = PasswordBox.Password;

            if (UserService.Authenticate(username, password))
            {
                MessageBox.Show("Вход успешен!");
                var chatWindow = new ChatWindow();
                chatWindow.Show();
                this.Close(); 
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль.");
            }
        }
    }
}

