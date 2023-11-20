using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media.Animation;

using ConnectingDBToApp.Models;
using ConnectingDBToApp.Commands;
using ConnectingDBToApp.GlobalClasses;
using ConnectingDBToApp.Views.Pages;
using ConnectingDBToApp.Views.Windows;


namespace ConnectingDBToApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
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

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private SideBarItem _selectedSideBarItem = null!;
        public SideBarItem SelectedSideBarItem
        {
            get { return _selectedSideBarItem; }
            set
            {
                _selectedSideBarItem = value;
                OnPropertyChanged(nameof(SelectedSideBarItem));
            }
        }

        public ICommand SelectedChangedCommand =>
            new DelegateCommand(
                execute: (_) =>
                {
                    switch (SelectedSideBarItem.Title)
                    {
                        case "SSMS":
                            GlobalObjs.MainFrame.Navigate(new SSMSPage()); break;
                        case "SQLite":
                            GlobalObjs.MainFrame.Navigate(new SQLitePage()); break;
                        case "Тест":
                            GlobalObjs.MainFrame.Navigate(new TestPage()); break;
                    }
                }
            );

        public ICommand MinimizeWindow => 
            new DelegateCommand(execute: (obj) => MainWindowMethods.Minimize!());

        public ICommand FullScreenWindow => 
            new DelegateCommand(execute: (obj) => MainWindowMethods.FullScreen!());

        public ICommand CloseWindow => 
            new DelegateCommand(execute: (obj) => MainWindowMethods.Close!());

        public ICommand ShowSideBar => 
            new DelegateCommand(
                execute: (item) =>
                {
                    var sideBar = (ListBox)item;

                    var animation = new DoubleAnimation();
                    animation.EasingFunction = new QuadraticEase() { EasingMode = EasingMode.EaseOut };
                    animation.Duration = TimeSpan.FromMilliseconds(200);

                    switch(sideBar.Width) 
                    {
                        case 230:
                            animation.To = 0; break;
                        case 0: 
                            animation.To = 230; break;
                    }

                    sideBar.BeginAnimation(FrameworkElement.WidthProperty, animation);
                }
            );

        public ICommand OpenAboutBox =>
            new DelegateCommand(execute: (item) => new AboutBoxWindow().Show());
    }
}
