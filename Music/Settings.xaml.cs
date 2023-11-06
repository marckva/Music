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
using System.Windows.Shapes;

namespace Music
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void BackToMainButton_Click(object sender, RoutedEventArgs e)
        {
            playermainWindow registrationWindow = new playermainWindow();
            registrationWindow.Show(); // Открываем окно регистрации
            this.Close(); // Закрываем текущее окно авторизации, если нужно
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

            CheckBox checkBox = sender as CheckBox; // Получаем ссылку на объект CheckBox
            if (checkBox != null)
            {
                if (checkBox.IsChecked == true)
                {
                    // CheckBox отмечен, переключаем на темную тему
                    Application.Current.Resources.MergedDictionaries[0] = new ResourceDictionary { Source = new Uri("Resourses/DarkTheme.xaml", UriKind.Relative) };
                }
                else
                {
                    // CheckBox не отмечен, переключаем на светлую тему
                    Application.Current.Resources.MergedDictionaries[0] = new ResourceDictionary { Source = new Uri("Resourses/LightTheme.xaml", UriKind.Relative) };
                }
            }

        }

    }
}
