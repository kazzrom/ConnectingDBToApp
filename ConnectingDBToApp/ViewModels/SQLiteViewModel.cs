using System;
using System.Linq;
using System.Windows;
using System.Diagnostics;
using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

using ConnectingDBToApp.Models;
using ConnectingDBToApp.GlobalClasses;
using ConnectingDBToApp.Views.Windows;


namespace ConnectingDBToApp.ViewModels
{
    public partial class SQLiteViewModel : ObservableObject
    {
        public SQLiteViewModel()
        {
            // Получение данных из базы данных
            CreatingDbItems = new ObservableCollection<SQLiteElement>(DbContext.Tables.SQLiteElements.Where(item => item.Chapter == "CreatingDB"));
            EFCoreConnectingDbItems = new ObservableCollection<SQLiteElement>(DbContext.Tables.SQLiteElements.Where(item => item.Chapter == "EFCoreConnectingDB"));
        }

        // Поле с элементами раздела "Создание БД"
        [ObservableProperty]
        private ObservableCollection<SQLiteElement> _creatingDbItems;

        // Поле с элементами раздела "Подключение БД"
        [ObservableProperty]
        private ObservableCollection<SQLiteElement> _EFCoreConnectingDbItems;

        // Команда для копирования текста
        [RelayCommand]
        private void CopyText(string code)
        {
            Clipboard.SetText(code);
            new MessageWindow("Скопировано!").ShowDialog();
        }

        // Команда для открытия ссылки
        [RelayCommand]
        private void NavigateLink(string link)
        {
            Process.Start(new ProcessStartInfo(link) { UseShellExecute = true });
        }

        // Команда для перехода к другой вкладке
        [RelayCommand]
        private void NavigatePart(object i)
        {
            var index = Convert.ToInt32(i);
            GlobalObjs.SQLiteTabControl.SelectedIndex = index;
            GlobalObjs.MainScrollViewer.ScrollToHome();
        }
    }
}
