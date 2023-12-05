using System;
using System.Windows;
using System.Windows.Media.Animation;

using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.ComponentModel;

using ConnectingDBToApp.Messages;
using ConnectingDBToApp.GlobalClasses;
using ConnectingDBToApp.Views.Pages;
using ConnectingDBToApp.Views.Windows;


namespace ConnectingDBToApp.ViewModels
{
    public partial class TestViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _username = string.Empty;

        [RelayCommand]
        private void OpenTest()
        {
            if (string.IsNullOrEmpty(Username)) 
            {
                new MessageWindow("Введите имя!").ShowDialog();
                return;
            }

            var animation = new DoubleAnimation()
            {
                To = 0,
                Duration = TimeSpan.FromMilliseconds(200)
            };
            animation.EasingFunction = new QuadraticEase() { EasingMode = EasingMode.EaseOut };

            GlobalObjs.MenuButton.IsEnabled = false;
            GlobalObjs.SideBar.BeginAnimation(FrameworkElement.WidthProperty, animation);

            GlobalObjs.MainFrame.Navigate(new QuestionPage());
            WeakReferenceMessenger.Default.Send(new GetUsernameMessage(Username));
        }

        [RelayCommand]
        private void OpenAllResults()
        {
            GlobalObjs.MainFrame.Navigate(new AllResultsPage());
        }
    }
}
