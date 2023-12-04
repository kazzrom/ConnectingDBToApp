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
        [ObservableProperty]
        private ObservableCollection<SQLiteElement> _creatingDbItems;

        [ObservableProperty]
        private ObservableCollection<SQLiteElement> _EFCoreConnectingDbItems;
        public SQLiteViewModel()
        {
            CreatingDbItems = new ObservableCollection<SQLiteElement>(DbContext.Tables.SQLiteElements.Where(item => item.Chapter == "CreatingDB"));
            EFCoreConnectingDbItems = new ObservableCollection<SQLiteElement>(DbContext.Tables.SQLiteElements.Where(item => item.Chapter == "EFCoreConnectingDB"));
        }

        [RelayCommand]
        private void CopyText(string code)
        {
            Clipboard.SetText(code);
            new MessageWindow("Скопировано!").ShowDialog();
        }

        [RelayCommand]
        private void NavigateLink(string link)
        {
            Process.Start(new ProcessStartInfo(link) { UseShellExecute = true });
        }

        [RelayCommand]
        private void NavigatePart(object i)
        {
            var index = Convert.ToInt32(i);
            GlobalObjs.SQLiteTabControl.SelectedIndex = index;
            GlobalObjs.MainScrollViewer.ScrollToHome();
        }
    }
}
