using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
    /// Логика взаимодействия для playermainWindow.xaml
    /// </summary>
    public partial class playermainWindow : Window
    {
       
        public playermainWindow()
        {
            InitializeComponent();
        }
        private Dictionary<string, string> trackImages = new Dictionary<string, string>
        {
            { "Трек 1", "Images/hajime1.jpg" },
            { "Трек 2", "Images/hajime2.jpg" },
          
            // Добавьте другие треки и соответствующие изображения
        };


        private int currentTrackIndex = 0;
        private List<string> tracks = new List<string>
        {
            "Трек 1",
            "Трек 2",

        };


        private void GotoSettingButton_Click(object sender, RoutedEventArgs e)
        {
            Settings registrationWindow = new Settings();
            registrationWindow.Show(); // Открываем окно регистрации
            this.Close(); // Закрываем текущее окно авторизации, если нужно
        }

        private void balanceSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        //НИХУЯ НЕ РАБОТАЕТ ФИКСИ ЭТУ ХУЙНЮ САМ (FOR GOXLESS)!!!!!!!!!!!!!!!!!!!!!!!
        //СУТЬ : ОН НЕ МЕНЯЕТ ИЗОБРАЖЕНИЕ ПРИ СМЕНЕ ЭЛЕМЕНТА КОМБОБОКСА.
        private void TrackComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TrackComboBox.SelectedItem != null)
            {
                string selectedTrack = TrackComboBox.SelectedItem.ToString();

                // Проверьте, есть ли изображение для выбранного трека в словаре trackImages
                if (trackImages.ContainsKey(selectedTrack))
                {
                    string imagePath = trackImages[selectedTrack];
                    TrackImage.Source = new BitmapImage(new Uri(imagePath, UriKind.Relative));
                }
                else
                {
                    // Если изображение отсутствует в словаре, вы можете установить
                    // изображение по умолчанию или выполнять другие действия.
                }
            }

            int currentTrackIndex = 0; // Начнем с первого трека
        }


        private void NextTrackButton_Click(object sender, RoutedEventArgs e)
        {
            // Увеличиваем индекс на 1, чтобы переключиться на следующий трек
            currentTrackIndex++;

            // Проверяем, не превышает ли индекс количество треков
            if (currentTrackIndex >= tracks.Count)
                {
                    // Если превышает, вернемся к первому треку
                    currentTrackIndex = 0;
                }

            // Теперь мы имеем индекс нового трека, который нужно воспроизвести
            string nextTrack = tracks[currentTrackIndex];

            // Ваша логика для воспроизведения следующего трека здесь
            // Например, установка источника для MediaElement и вызов Play()

            // Обновим информацию о треке
            TrackComboBox.SelectedIndex = currentTrackIndex;
            TrackComboBox.Text = nextTrack; // Установка текста в ComboBox

            // Обновим изображение играющего трека (если используете изображения)
            if (trackImages.ContainsKey(nextTrack))
                {
                    string imagePath = trackImages[nextTrack];
                    TrackImage.Source = new BitmapImage(new Uri(imagePath, UriKind.Relative));
                }

        }

        private void TrackBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void volumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}
