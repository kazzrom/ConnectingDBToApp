using ConnectingDBToApp.Commands;
using ConnectingDBToApp.GlobalClasses;
using ConnectingDBToApp.Models;
using ConnectingDBToApp.Views.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace ConnectingDBToApp.ViewModels
{
    public class TestViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public ICommand OpenTest => 
            new DelegateCommand(
                execute: (obj) =>
                {
                    DoubleAnimation animation = new DoubleAnimation() 
                    { 
                        To = 0,
                        Duration = TimeSpan.FromMilliseconds(200)
                    };
                    animation.EasingFunction = new QuadraticEase() { EasingMode = EasingMode.EaseOut };

                    GlobalObjs.MenuButton.IsEnabled = false;
                    GlobalObjs.SideBar.BeginAnimation(FrameworkElement.WidthProperty, animation);
                    GlobalObjs.MainFrame.Navigate(new QuestionPage());
                    GlobalObjs.Result.Username = Username;
                }
            );
    }
}
