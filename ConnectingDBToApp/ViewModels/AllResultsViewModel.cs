using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

using ConnectingDBToApp.Models;
using ConnectingDBToApp.GlobalClasses;
using System.Windows.Navigation;


namespace ConnectingDBToApp.ViewModels
{
    public partial class AllResultsViewModel : ObservableObject
    {
        public AllResultsViewModel() 
        { 
            Results = new ObservableCollection<TestResult>(DbContext.Tables.TestResults);
        }

        [ObservableProperty]
        private ObservableCollection<TestResult> _results;

        [RelayCommand]
        private void BackPage()
        {
            GlobalObjs.MainFrame.GoBack();
        }
    }
}
