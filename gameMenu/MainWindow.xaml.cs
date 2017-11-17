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
using Microsoft.Win32;
using System.IO;

namespace gameMenu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        static private MediaPlayer playsong = new MediaPlayer();
        public MainWindow()
        {
            InitializeComponent();
            playS();

            menubck.Source = new Uri(Directory.GetCurrentDirectory() + "\\menubck.mp4", UriKind.Absolute);
            menubck.Play();

        }
        private  void playS()
        {
            Uri uri = new Uri(Directory.GetCurrentDirectory() + "\\menu.mp3", UriKind.Absolute);
            playsong.Open(uri);
            playsong.MediaEnded += Playsong_MediaEnded;
            playsong.Play();
        }
        /// <summary>
        /// Helps for the background music to be infinity
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Playsong_MediaEnded(object sender, EventArgs e)
        {
            playsong.Play();
        }
        /// <summary>
        /// Helps for the background to be infinity
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            menubck.Source = new Uri(Directory.GetCurrentDirectory() + "\\menubck.mp4", UriKind.Absolute);
            menubck.Play();
        }

        private void newGame_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            gameWindow gw = new gameWindow();
            gw.Show();
        }

        private void score_btn_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void exit_btn_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
