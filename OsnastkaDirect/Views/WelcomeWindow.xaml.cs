using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OsnastkaDirect.Views
{
    /// <summary>
    /// Логика взаимодействия для WelcomeWindow.xaml
    /// </summary>
    public partial class WelcomeWindow : Window
    {
        public WelcomeWindow()
        {
            InitializeComponent();
            //neuro.Position = new TimeSpan(0, 0, 1);
            neuro.Play();
            neuro.Position = new TimeSpan(10, 1, 1);
            //neuro.Pause();
        }

        private void myMediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            ((MediaElement)sender).Position = new TimeSpan(0, 0, 1);
        }

        private void neuro_MediaOpened(object sender, RoutedEventArgs e)
        {
            neuro.Pause();
        }

        private void neuro_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            neuro.Play();
        }
    }
}
