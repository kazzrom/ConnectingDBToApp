using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.ComponentModel;

using ConnectingDBToApp.Models;
using ConnectingDBToApp.Messages;
using ConnectingDBToApp.GlobalClasses;
using ConnectingDBToApp.Views.Pages;


namespace ConnectingDBToApp.ViewModels
{
    public partial class ResultViewModel : ObservableObject, IRecipient<GetTestResultMessage>
    {
        public ResultViewModel() 
        {
            // Регистрация класса как получателя сообщений
            WeakReferenceMessenger.Default.Register(this);
        }

        // Поле с результатом теста
        [ObservableProperty]
        private TestResult _result = null!;

        // Метод для получения сообщения о результате пользователя
        public void Receive(GetTestResultMessage message)
        {
            Result = message.Value;
            WeakReferenceMessenger.Default.UnregisterAll(this);
        }

        // Команда для возвращения на начальную страницу теста
        [RelayCommand]
        private void NavigateTestPage()
        {
            GlobalObjs.MainFrame.Navigate(new TestPage());
        }
    }
}
