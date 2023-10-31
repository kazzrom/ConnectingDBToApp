using ConnectingDBToApp.GlobalClasses;
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
using System.Windows.Media.Animation;
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

            MainFrame.Frame = MainFrameApp;
            MainWindowMethods.Minimize = () => { WindowState = WindowState.Minimized; };
            MainWindowMethods.Close = () => { Close(); };
            MainWindowMethods.Fullscreen = () => 
            {
                switch (WindowState)
                {
                    case WindowState.Normal:
                        WindowState = WindowState.Maximized; break;
                    case WindowState.Maximized:
                        WindowState = WindowState.Normal; break;
                }
            };
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
