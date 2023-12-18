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
            // Получение всех результатов из базы данных
            Results = new ObservableCollection<TestResult>(DbContext.Tables.TestResults);
        }

        // Поле всех результатов
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ClearResultsCommand))]
        private ObservableCollection<TestResult> _results;

        // Команда возвращения на начальную страницу теста
        [RelayCommand]
        private void BackPage()
        {
            GlobalObjs.MainFrame.GoBack();
        }

        // Команда для удаления всех результатов пользователей
        [RelayCommand(CanExecute = nameof(CanClearResults))]
        private void ClearResults()
        {
            DbContext.Tables.TestResults.RemoveRange(Results);
            DbContext.Tables.SaveChanges();
            Results.Clear();
        }

        // Метод, отвечающий за активность кнопки для удаления всех результатов
        private bool CanClearResults()
        {
            return Results.Count > 0;
        }
    }
}
