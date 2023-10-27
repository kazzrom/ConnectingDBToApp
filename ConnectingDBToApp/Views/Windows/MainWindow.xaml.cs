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

namespace ConnectingDBToApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MinimizeWindow(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void FullScreenWindow(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;

            switch (WindowState)
            {
                case WindowState.Normal:
                    button.Content = Resources["Image.FullscreenExit"];
                    WindowState = WindowState.Maximized;
                    break;
                case WindowState.Maximized:
                    button.Content = Resources["Image.Fullscreen"];
                    WindowState = WindowState.Normal;
                    break;
            }
        }

        private void HeaderWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }
    }
}
