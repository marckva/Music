using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Music
{
    /// <summary>
    /// Логика взаимодействия для Registr.xaml
    /// </summary>
    public partial class Registr : Window
    {
        public Registr()
        {
            InitializeComponent();
        }
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {

            // Получаем введенный адрес электронной почты
            string email = EmailTextBox.Text;

            // Регулярное выражение для проверки формата почты
            string emailPattern = @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$";

            if (!Regex.IsMatch(email, emailPattern))
            {
                MessageBox.Show("Пожалуйста, введите правильный адрес электронной почты.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Получаем введенные пароли
            string password1 = PasswordBox1.Password;
            string password2 = PasswordBox2.Password;

            if (string.IsNullOrEmpty(password1) || string.IsNullOrEmpty(password2))
            {
                MessageBox.Show("Поле пароля не может быть пустым. Пожалуйста, введите пароль.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (password1 != password2)
            {
                MessageBox.Show("Пароли не совпадают. Пожалуйста, повторите ввод пароля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            playermainWindow registrationWindow = new playermainWindow();
            registrationWindow.Show(); // Открываем окно регистрации
            this.Close(); // Закрываем текущее окно авторизации, если нужно

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow registrationWindow = new MainWindow();
            registrationWindow.Show(); // Открываем окно регистрации
            this.Close(); // Закрываем текущее окно авторизации, если нужно
        }
    }
}
