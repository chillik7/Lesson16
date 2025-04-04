using System.Windows;

namespace MultiplayerApp.Views
{
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }
        private void OnRegisterClick(object sender, RoutedEventArgs e)
        {
            var viewModel = new RegisterViewModel
            {
                Username = UsernameTextBox.Text,
                Password = PasswordBox.Password
            };
            viewModel.Register();
            MessageBox.Show("Пользователь зарегистрирован!");
        }
    }
}
