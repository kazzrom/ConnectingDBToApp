using System;
using System.Linq;
using System.Windows;
using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

using ConnectingDBToApp.Models;
using ConnectingDBToApp.GlobalClasses;
using ConnectingDBToApp.Views.Windows;


namespace ConnectingDBToApp.ViewModels
{
    public partial class SSMSViewModel : ObservableObject
    {
        public SSMSViewModel()
        {
            // Получение данных из базы данных
            CreatingDbItems = new ObservableCollection<SSMSElement>(DbContext.Tables.SSMSElements.Where(item => item.Chapter == "CreatingDB"));
            ConnectionDBItems = new ObservableCollection<SSMSElement>(DbContext.Tables.SSMSElements.Where(item => item.Chapter == "ConnectionDB"));
            SQLClientDownloadItems = new ObservableCollection<SSMSElement>(DbContext.Tables.SSMSElements.Where(item => item.Chapter == "SQLClientDownload"));
            SQLClientConnectionDBItems = new ObservableCollection<SSMSElement>(DbContext.Tables.SSMSElements.Where(item => item.Chapter == "SQLClientConnectionDB"));
            SQLClientQueryExecutionItems = new ObservableCollection<SSMSElement>(DbContext.Tables.SSMSElements.Where(item => item.Chapter == "SQLClientQueryExecution"));
            EFCore7Items = new ObservableCollection<SSMSElement>(DbContext.Tables.SSMSElements.Where(item => item.Chapter == "EFCore7"));
        }

        // Поле с элементами раздела "Создание БД"
        [ObservableProperty]
        private ObservableCollection<SSMSElement> _creatingDbItems;

        // Поле с элементами раздела "Соединение БД в VS"
        [ObservableProperty]
        private ObservableCollection<SSMSElement> _connectionDBItems;

        // Поле с элементами раздела "Установка SqlClient"
        [ObservableProperty]
        private ObservableCollection<SSMSElement> _SQLClientDownloadItems;

        // Поле с элементами раздела "Подключение БД"
        [ObservableProperty]
        private ObservableCollection<SSMSElement> _SQLClientConnectionDBItems;

        // Поле с элементами раздела "Выполнение запросов"
        [ObservableProperty]
        private ObservableCollection<SSMSElement> _SQLClientQueryExecutionItems;

        // Поле с элементами раздела "Работа с EF Core 7"
        [ObservableProperty]
        private ObservableCollection<SSMSElement> _EFCore7Items;

        // Команда для копирования текста
        [RelayCommand]
        private void CopyText(string code)
        {
            Clipboard.SetText(code);
            new MessageWindow("Cкопировано!").ShowDialog();
        }

        // Команда для перехода к другой вкладке
        [RelayCommand]
        private void NavigatePart(object i)
        {
            var index = Convert.ToInt32(i);
            GlobalObjs.SMMSTabControl.SelectedIndex = index;
            GlobalObjs.MainScrollViewer.ScrollToHome();
        }

        // Команда для перехода к другой подвкладке
        [RelayCommand]
        private void NavigateSubPart(object i)
        {
            var index = Convert.ToInt32(i);
            GlobalObjs.SMMSSubTabControl.SelectedIndex = index;
            GlobalObjs.MainScrollViewer.ScrollToHome();
        }
    }
}
