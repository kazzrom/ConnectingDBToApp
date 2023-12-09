using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

using ConnectingDBToApp.Models;
using ConnectingDBToApp.GlobalClasses;


namespace ConnectingDBToApp.ViewModels
{
    public partial class AllResultsViewModel : ObservableObject
    {
        public AllResultsViewModel() 
        { 
            Results = new ObservableCollection<TestResult>(DbContext.Tables.TestResults);
        }

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ClearResultsCommand))]
        private ObservableCollection<TestResult> _results;

        [RelayCommand]
        private void BackPage()
        {
            GlobalObjs.MainFrame.GoBack();
        }

        [RelayCommand(CanExecute = nameof(CanClearResults))]
        private void ClearResults()
        {
            DbContext.Tables.TestResults.RemoveRange(Results);
            DbContext.Tables.SaveChanges();
            Results.Clear();
        }

        private bool CanClearResults()
        {
            return Results.Count > 0;
        }
    }
}
