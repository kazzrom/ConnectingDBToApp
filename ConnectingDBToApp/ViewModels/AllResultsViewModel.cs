using System.Windows.Input;
using System.ComponentModel;
using System.Collections.ObjectModel;

using ConnectingDBToApp.Models;
using ConnectingDBToApp.Commands;
using ConnectingDBToApp.GlobalClasses;


namespace ConnectingDBToApp.ViewModels
{
    public class AllResultsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<TestResult> Results { get; set; } = null!;

        public AllResultsViewModel() 
        { 
            Results = new ObservableCollection<TestResult>(DbContext.Tables.TestResults);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand BackPage =>
            new DelegateCommand(
                execute: (obj) =>
                {
                    GlobalObjs.MainFrame.GoBack();
                }
            );
    }
}
