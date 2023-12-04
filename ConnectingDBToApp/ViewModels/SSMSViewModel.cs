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
        [ObservableProperty]
        private ObservableCollection<SSMSElement> _creatingDbItems;

        [ObservableProperty]
        private ObservableCollection<SSMSElement> _connectionDBItems;

        [ObservableProperty]
        private ObservableCollection<SSMSElement> _SQLClientDownloadItems;

        [ObservableProperty]
        private ObservableCollection<SSMSElement> _SQLClientConnectionDBItems;

        [ObservableProperty]
        private ObservableCollection<SSMSElement> _SQLClientQueryExecutionItems;

        [ObservableProperty]
        private ObservableCollection<SSMSElement> _EFCore7Items;

        public SSMSViewModel()
        {
            CreatingDbItems = new ObservableCollection<SSMSElement>(DbContext.Tables.SSMSElements.Where(item => item.Chapter == "CreatingDB"));
            ConnectionDBItems = new ObservableCollection<SSMSElement>(DbContext.Tables.SSMSElements.Where(item => item.Chapter == "ConnectionDB"));
            SQLClientDownloadItems = new ObservableCollection<SSMSElement>(DbContext.Tables.SSMSElements.Where(item => item.Chapter == "SQLClientDownload"));
            SQLClientConnectionDBItems = new ObservableCollection<SSMSElement>(DbContext.Tables.SSMSElements.Where(item => item.Chapter == "SQLClientConnectionDB"));
            SQLClientQueryExecutionItems = new ObservableCollection<SSMSElement>(DbContext.Tables.SSMSElements.Where(item => item.Chapter == "SQLClientQueryExecution"));
            EFCore7Items = new ObservableCollection<SSMSElement>(DbContext.Tables.SSMSElements.Where(item => item.Chapter == "EFCore7"));
        }

        [RelayCommand]
        private void CopyText(string code)
        {
            Clipboard.SetText(code);
            new MessageWindow("Cкопировано!").ShowDialog();
        }

        [RelayCommand]
        private void NavigatePart(object i)
        {
            var index = Convert.ToInt32(i);
            GlobalObjs.SMMSTabControl.SelectedIndex = index;
            GlobalObjs.MainScrollViewer.ScrollToHome();
        }

        [RelayCommand]
        private void NavigateSubPart(object i)
        {
            var index = Convert.ToInt32(i);
            GlobalObjs.SMMSSubTabControl.SelectedIndex = index;
            GlobalObjs.MainScrollViewer.ScrollToHome();
        }
    }
}
