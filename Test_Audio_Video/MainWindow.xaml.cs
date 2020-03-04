using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
using System.Windows.Threading;

namespace Test_Audio_Video
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		int segundos;
		private MediaPlayer mediaPlayer = new MediaPlayer();
		public MainWindow()
        {
            InitializeComponent();
			segundos = 0;
        }

		private void btnAsterisk_Click(object sender, RoutedEventArgs e)
		{
			SystemSounds.Asterisk.Play();
		}

		private void btnBeep_Click(object sender, RoutedEventArgs e)
		{
			SystemSounds.Beep.Play();
		}

		private void btnExclamation_Click(object sender, RoutedEventArgs e)
		{
			SystemSounds.Exclamation.Play();
		}

		private void btnHand_Click(object sender, RoutedEventArgs e)
		{
			SystemSounds.Hand.Play();
		}

		private void btnQuestion_Click(object sender, RoutedEventArgs e)
		{
			SystemSounds.Question.Play();
		}

		private void btnOpenAudioFile_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
			if (openFileDialog.ShowDialog() == true)
			{
				mediaPlayer.Open(new Uri(openFileDialog.FileName));
				//mediaPlayer.Play();
			}

			//Es como el timer de WinForms
			DispatcherTimer timer = new DispatcherTimer();//CREO EL TIME
			timer.Interval = TimeSpan.FromMilliseconds(1000);//LE ESTABLEZCO EL LAPSO DE TIEMPO
			timer.Tick += timer_Tick; //EL EVENTO QUE EJECUTARA
			timer.Start();
		}
		void timer_Tick(object sender, EventArgs e)
		{
			//lblStatus.Content = segundos.ToString();
			lblStatus.Content = DateTime.Now.ToLongTimeString();
			segundos++;
			/*if (mediaPlayer.Source != null)
				lblStatus.Content = String.Format("{0} / {1}", mediaPlayer.Position.ToString(@"mm\:ss"), mediaPlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
			else
				lblStatus.Content = "No file selected...";*/
		}

		private void btnPlay_Click(object sender, RoutedEventArgs e)
		{
			mediaPlayer.Play();
			//Es como el timer de WinForms
			DispatcherTimer timer = new DispatcherTimer();//CREO EL TIME
			timer.Interval = TimeSpan.FromSeconds(1);//LE ESTABLEZCO EL LAPSO DE TIEMPO
			timer.Tick += timer_Tick; //EL EVENTO QUE EJECUTARA
			timer.Start();
		}

		private void btnPause_Click(object sender, RoutedEventArgs e)
		{
			mediaPlayer.Pause();
		}

		private void btnStop_Click(object sender, RoutedEventArgs e)
		{
			mediaPlayer.Stop();
		}
	}
}
