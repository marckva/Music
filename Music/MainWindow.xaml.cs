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

namespace Music
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Обработка события при нажатии кнопки "Login"
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            playermainWindow registrationWindow = new playermainWindow();
            registrationWindow.Show(); // Открываем окно регистрации
            this.Close(); // Закрываем текущее окно авторизации, если нужно


        }
        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            Registr registrationWindow = new Registr();
            registrationWindow.Show(); // Открываем окно регистрации
            this.Close(); // Закрываем текущее окно авторизации, если нужно
        }

        public MainWindow()
        {

            InitializeComponent();

        }
    }
}
