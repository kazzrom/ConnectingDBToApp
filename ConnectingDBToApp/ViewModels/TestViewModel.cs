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
        // Поле с именем пользователя
        [ObservableProperty]
        private string _username = string.Empty;

        // Команда для открытия теста
        [RelayCommand]
        private void OpenTest()
        {
            // Проверка, не пусто ли свойство с именем пользователя
            if (string.IsNullOrEmpty(Username)) 
            {
                new MessageWindow("Пустое поле ввода.\nВведите имя!").ShowDialog();
                return;
            }
            // Проверка на максимальное количество символов имени пользователя
            else if (Username.Length > 16)
            {
                new MessageWindow("Слишком длинное имя!").ShowDialog();
                return;
            }

            // Скрытие бокового меню и кнопки, скрывающая/показывающая меню
            var animation = new DoubleAnimation()
            {
                To = 0,
                Duration = TimeSpan.FromMilliseconds(200)
            };
            animation.EasingFunction = new QuadraticEase() { EasingMode = EasingMode.EaseOut };

            GlobalObjs.MenuButton.IsEnabled = false;
            GlobalObjs.SideBar.BeginAnimation(FrameworkElement.WidthProperty, animation);

            // Переход на страницу с вопросом теста
            GlobalObjs.MainFrame.Navigate(new QuestionPage());

            // Отправка сообщения с именем пользователя на страницу с вопросом теста
            WeakReferenceMessenger.Default.Send(new GetUsernameMessage(Username));
        }

        // Команда для перехода на страницу всех результатов
        [RelayCommand]
        private void OpenAllResults()
        {
            GlobalObjs.MainFrame.Navigate(new AllResultsPage());
        }
    }
}
