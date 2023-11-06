using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using NAudio.Wave;
using TagLib;
using System.Net.Http;
using Music.GlobalClass;
using System.Windows.Forms;

namespace Music
{
    /// <summary>
    /// Логика взаимодействия для playermainWindow.xaml
    /// </summary>
    public partial class playermainWindow : Window
    {
        private TextBlock CurrentTrack;
        private MediaPlayer player = new MediaPlayer();
        private string filePath = "C:/Users/pcuser/Desktop/mus/COI.mp3";
        private TimeSpan totalTime;
        private System.Windows.Threading.DispatcherTimer timer;
        private bool isPlaying;
        Monga mongaInstance = new Monga();
        private int currentTrackIndex = 0;





        public playermainWindow()
        {
            InitializeComponent();
            this.player.Open(new Uri(filePath));
            this.player.MediaOpened += (source, args) =>

            {
                sliderDuration.Maximum = 100;

                this.totalTime = this.player.NaturalDuration.TimeSpan;
                this.timer = new System.Windows.Threading.DispatcherTimer();
                this.timer.Interval = TimeSpan.FromSeconds(1);
                this.timer.Tick += new EventHandler(Timer_Tick);
                this.timer.Start();
                this.sliderDuration.AddHandler(MouseLeftButtonUpEvent,
                      new MouseButtonEventHandler(sliderDuration_MouseClickUp),
                      true);

                CurrentTrack = new TextBlock();
                this.player.MediaEnded += Player_MediaEnded;

            };

            this.isPlaying = false;
        }
        private bool isRepeatEnabled = false;


        private void Player_MediaEnded(object sender, EventArgs e)
        {
            {
                // Трек закончился, переключаемся на следующий или зацикливаем текущий
                if (isRepeatEnabled)
                {
                    // Если рипит включен, зацикливаем текущий трек
                    PlayCurrentTrack();
                }
                else
                {
                    // Иначе переключаемся на следующий трек
                    PlayNextTrack();
                }
            }

        }

        private void PlayNextTrack()
        {
            currentTrackIndex++;

            if (currentTrackIndex >= playlist.Count)
            {
                currentTrackIndex = 0; 
            }

            filePath = playlist[currentTrackIndex];

            player.Close();
            player.Open(new Uri(filePath));

            player.Play();

            CurrentTrack.Text = System.IO.Path.GetFileNameWithoutExtension(filePath);

            ExtractAndSetCover(filePath);
        }

        private List<string> playlist = new List<string>

        {
             "C:/Users/pcuser/Desktop/mus/COI.mp3",
             "C:/Users/pcuser/Desktop/mus/Durak.mp3",
             "C:/Users/pcuser/Desktop/mus/Kino.mp3",
             "C:/Users/pcuser/Desktop/mus/Lumen.mp3",
            //  другие треки 
        };

        private void Timer_Tick(object sender, EventArgs e)
        {


            if (this.player.NaturalDuration.HasTimeSpan)
            {
                double delay = this.player.Position.TotalSeconds / totalTime.TotalSeconds * 100;
                if (this.totalTime.TotalSeconds > 0 && this.player.NaturalDuration.TimeSpan.TotalSeconds > 0)
                {
                    sliderDuration.Value = delay;
                }
            }
            else
            {
                // Обработка ситуации, когда NaturalDuration имеет "Automatic"
                sliderDuration.Value = 0;
            }
        }
        private void BTN_Play(object sender, RoutedEventArgs e)
        {
            if (isPlaying)
            {
                ResetSoundCover();
                changePlayingStatus();
                this.player.Pause();
            }
            else
            {
                ExtractAndSetCover(filePath);
                changePlayingStatus();
                this.player.Play();
            }

        }

        private void changePlayingStatus()
        {
            this.isPlaying = !this.isPlaying;
        }

        private void ResetSoundCover()
        {
            SoundCover.Source = new BitmapImage(new Uri("C:/Users/pcuser/Desktop/2137cf.png"));
        }

        private void ExtractAndSetCover(string mp3FilePath)
        {
            try
            {
                var mp3File = TagLib.File.Create(filePath);

                if (mp3File.Tag.Pictures.Length > 0)
                {
                    var picture = mp3File.Tag.Pictures[0];
                    var bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = new System.IO.MemoryStream(picture.Data.Data);
                    bitmapImage.EndInit();

                    SoundCover.Source = bitmapImage;
                }
            }
            catch (Exception ex)
            {
                // Обработка ошибок при извлечении обложки
                Console.WriteLine("Ошибка при извлечении обложки: " + ex.Message);
            }
        }

        private void ResetBackground()
        {
            // Сброс фона на изображение по умолчанию или другое изображение=
            Background = new ImageBrush(new BitmapImage(new Uri("C:/Users/pcuser/Desktop/2137cf.png")));
        }

        private void ChangeCover(object sender, RoutedEventArgs e)
        {

        }

        private void CheckRepeat_Checked(object sender, RoutedEventArgs e)
        {
            isRepeatEnabled = true;
            this.player.MediaEnded += (source, args) =>
            {
                this.player.Position = TimeSpan.Zero;
                this.player.Play();
            };
        }

        private void CheckRepeat_Unchecked(object sender, RoutedEventArgs e)
        {
            isRepeatEnabled = false;
            this.player.MediaEnded -= (source, args) =>
            {
                this.player.Position = TimeSpan.Zero;
                this.player.Play();
            };
        }

        private void sliderVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (isPlaying)
            {
                this.player.Pause();
                double volume = sliderVolume.Value;
                this.player.Volume = volume;
                this.player.Play();
            }
            else
            {
                double volume = sliderVolume.Value;
                this.player.Volume = volume;
            }
        }

        private void sliderDuration_MouseClickUp(object sender, MouseButtonEventArgs e)
        {
            this.player.Pause();

            double delay = (sliderDuration.Value * this.player.NaturalDuration.TimeSpan.TotalSeconds) / 100;

            if (totalTime.TotalSeconds > 0)
                this.player.Position = TimeSpan.FromSeconds(delay);

            this.player.Play();
        }

        private void sliderDuration_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void BTN_Previous(object sender, RoutedEventArgs e)
        {
            
            currentTrackIndex--;

            // Проверка, не стал ли индекс отрицательным
            if (currentTrackIndex < 0)
            {
                currentTrackIndex = playlist.Count - 1; // Если да, вернитесь к концу списка
            }

            filePath = playlist[currentTrackIndex];

            player.Close();
            player.Open(new Uri(filePath));

            player.Play();

            CurrentTrack.Text = System.IO.Path.GetFileNameWithoutExtension(filePath);

            ExtractAndSetCover(filePath);
        }

        private void PlayTrackByFilePath(string filepath)
        {
            // остановка текущий таймер
            if (timer != null)
            {
                timer.Stop();
                timer.Tick -= Timer_Tick;
            }

            int index = playlist.FindIndex(track => track.Equals(filepath, StringComparison.OrdinalIgnoreCase));

            if (index != -1)
            {
                // Найден трек в плейлисте
                currentTrackIndex = (index + 1) % playlist.Count; //  индекс следующего трека
                filePath = playlist[currentTrackIndex]; //  путь к следующему треку

                player.Close();
                player.Open(new Uri(filePath));
                player.Play();

                timer = new System.Windows.Threading.DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Tick += new EventHandler(Timer_Tick);
                timer.Start();

                CurrentTrack.Text = System.IO.Path.GetFileNameWithoutExtension(filePath);
                ExtractAndSetCover(filePath);
            }
            else
            {
                // Файл с указанным путем не найден в плейлисте
                System.Windows.Forms.MessageBox.Show("Трек с указанным путем не найден в плейлисте.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void PlayCurrentTrack()
        {
            player.Close();
            player.Open(new Uri(filePath));

            // Воспроизведите текущий трек
            player.Play();

            CurrentTrack.Text = System.IO.Path.GetFileNameWithoutExtension(filePath);

            ExtractAndSetCover(filePath);
        }

        private void BTN_Next(object sender, RoutedEventArgs e)
        {
            PlayTrackByFilePath(filePath);
        }
    }
}