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
    /// Логика взаимодействия для playermainWindow.xaml
    /// </summary>
    public partial class playermainWindow : Window
    {
        private MediaPlayer player = new MediaPlayer();
        private string filePath = "C:/Users/pcuser/Desktop/mus/Rollup.mp3";

        private string backgroundImage = "";

        public playermainWindow()
        {
            InitializeComponent();
            this.player.Open(new Uri(filePath));

        }
        private void BTN_Play(object sender, RoutedEventArgs e)
        {
            this.player.Play();
        }
        private void BTN_Stop(object sender, RoutedEventArgs e)
        {
            this.player.Stop();
        }
        private void BTN_Rewind_Forward(object sender, RoutedEventArgs e)
        {
        }

        private void ChangeCover(object sender, RoutedEventArgs e)
        {
            SoundCover.Source = BitmapFrame.Create(new Uri(filePath));
        }

        /*  <Grid>
        <Image Source = "C:\Users\Goxless\Desktop\dark-city-background-9880.jpg" Margin="0,0,0,0"  >
            <Image.Effect>
                <BlurEffect Radius = "4" />
            </ Image.Effect >
        </ Image >

        < Button Content="Play" HorizontalAlignment="Left" Margin="178,327,0,0" VerticalAlignment="Top" Width="75" Click="BTN_Play"/>
        <Button Content = "Stop" HorizontalAlignment="Left" Margin="354,327,0,0" VerticalAlignment="Top" Width="75" Click="BTN_Stop"/>
        <Button Content = "Rewind" HorizontalAlignment="Left" Margin="525,327,0,0" VerticalAlignment="Top" Width="75" Click="BTN_Rewind_Forward"/>


    </Grid>*/
    }
}

