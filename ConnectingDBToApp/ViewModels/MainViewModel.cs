using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

using ConnectingDBToApp.Models;
using ConnectingDBToApp.GlobalClasses;
using ConnectingDBToApp.Views.Pages;
using ConnectingDBToApp.Views.Windows;


namespace ConnectingDBToApp.ViewModels
{
    public enum Chapters
    {
        SSMS,
        SQLite,
        Test
    }

    public partial class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
        }


        [RelayCommand]
        private void SelectedChanged(ListBox listBox)
        {
            switch (listBox.SelectedIndex)
            {
                case (int)Chapters.SSMS:
                    GlobalObjs.MainFrame.Navigate(new SSMSPage()); break;
                case (int)Chapters.SQLite:
                    GlobalObjs.MainFrame.Navigate(new SQLitePage()); break;
                case (int)Chapters.Test:
                    GlobalObjs.MainFrame.Navigate(new TestPage()); break;
            }
        }

        [RelayCommand]
        private void MinimizeWindow() => MainWindowMethods.Minimize!();

        [RelayCommand]
        private void FullScreenWindow() => MainWindowMethods.FullScreen!();

        [RelayCommand]
        private void CloseWindow() => MainWindowMethods.Close!();

        [RelayCommand]
        private void ShowSideBar(ListBox sideBar)
        {
            var animation = new DoubleAnimation();
            animation.EasingFunction = new QuadraticEase() { EasingMode = EasingMode.EaseOut };
            animation.Duration = TimeSpan.FromMilliseconds(200);

            switch (sideBar.Width)
            {
                case 230:
                    animation.To = 0; break;
                case 0:
                    animation.To = 230; break;
            }

            sideBar.BeginAnimation(FrameworkElement.WidthProperty, animation);
        }

        [RelayCommand]
        private void OpenAboutBox() => new AboutBoxWindow().ShowDialog();
    }
}
