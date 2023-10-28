using ConnectingDBToApp.Commands;
using ConnectingDBToApp.GlobalClasses;
using ConnectingDBToApp.Models;
using ConnectingDBToApp.Views.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using static System.Net.Mime.MediaTypeNames;

namespace ConnectingDBToApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<SideBarItem> SideBarItems { get; set; }
        public MainViewModel() 
        { 
            SideBarItems = new ObservableCollection<SideBarItem>() 
            { 
                new SideBarItem()
                {
                    Title = "SSMS",
                    PathImage = "/Images/Icons/SSMS.png"
                },
                new SideBarItem()
                {
                    Title = "SQLite",
                    PathImage = "/Images/Icons/SQLite.png"
                },
                new SideBarItem()
                {
                    Title = "Тест",
                    PathImage = "/Images/Icons/Test.png"
                },
            };
        }

        private SideBarItem _sideBarItem;
        public SideBarItem SideBarItem
        {
            get { return _sideBarItem; }
            set
            {
                _sideBarItem = value;
                OnPropertyChanged(nameof(SideBarItem));

                switch (_sideBarItem.Title) 
                {
                    case "SSMS":
                        MainFrame.Frame.Navigate(new SSMSPage()); break;
                    case "SQLite":
                        MainFrame.Frame.Navigate(new SQLitePage()); break;
                    case "Тест":
                        MainFrame.Frame.Navigate(new TestPage()); break;
                    default:
                        MainFrame.Frame.Navigate(new TestPage()); break;
                }
            }
        }



        public ICommand MinimizeWindow
        {
            get => new DelegateCommand((obj) => { MainWindowMethods.Minimize(); });
        }

        public ICommand FullscreenWindow
        {
            get => new DelegateCommand((obj) => { MainWindowMethods.Fullscreen(); });
        }

        public ICommand CloseWindow
        {
            get => new DelegateCommand((obj) => { MainWindowMethods.Close(); });
        }

        public ICommand ShowSideBar
        {
            get => new DelegateCommand((item) =>
            {
                var sideBar = (ListBox)item;

                DoubleAnimation animation = new DoubleAnimation();
                animation.EasingFunction = new QuadraticEase() { EasingMode = EasingMode.EaseOut };
                animation.Duration = TimeSpan.FromMilliseconds(200);

                switch(sideBar.Width) 
                {
                    case 200:
                        animation.To = 0; break;
                    case 0: 
                        animation.To = 200; break;
                }

                sideBar.BeginAnimation(FrameworkElement.WidthProperty, animation);
            });
        }
    }
}
