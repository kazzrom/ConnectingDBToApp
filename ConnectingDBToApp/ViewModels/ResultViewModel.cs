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
            WeakReferenceMessenger.Default.Register(this);
        }

        [ObservableProperty]
        private TestResult _result = null!;

        public void Receive(GetTestResultMessage message)
        {
            Result = message.Value;
            WeakReferenceMessenger.Default.UnregisterAll(this);
        }

        [RelayCommand]
        private void NavigateTestPage()
        {
            GlobalObjs.MainFrame.Navigate(new TestPage());
        }
    }
}
