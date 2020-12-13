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
using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        SolidColorBrush grayBrush = new SolidColorBrush(Color.FromRgb(100, 100, 100));
        SolidColorBrush redBrush = new SolidColorBrush(Color.FromRgb(255, 0, 0));
        SolidColorBrush yellowBrush = new SolidColorBrush(Color.FromRgb(255, 255, 0));
        SolidColorBrush greenBrush = new SolidColorBrush(Color.FromRgb(0, 255, 0));
        double seconds = 13;
        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += timer_Tick;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            red.Fill = grayBrush;
            yellow.Fill = grayBrush;
            green.Fill = grayBrush;
            if (seconds >= 6 || seconds == 5 || seconds == 4)
            {
                green.Fill = greenBrush;
                if (seconds % 1 == 0) label.Content = Convert.ToString(seconds - 3) + " Мав";
                button.Content = "спасибо зеленый стрелощка";
            }
            else if (seconds == 5.5 || seconds == 4.5 || seconds == 3.5) green.Fill = grayBrush; 
            else if (seconds <= 3 && seconds > 0)
            {
                yellow.Fill = yellowBrush;
                label.Content = "0";
            }
            else if (seconds == 0)
            {
                yellow.Fill = grayBrush;
                red.Fill = redBrush;
                label.Content = "ХА! теперь жди :)";
                timer.Stop();
                seconds = 13;
                button.Content = "прапусти красный крестик";
            }
            seconds -= 0.5;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (button.Content == "спасибо зеленый стрелощка") seconds = 6;
            else seconds = 13;
            timer.Start();
        }
    }
}
