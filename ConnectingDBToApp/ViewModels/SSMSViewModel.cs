using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

using ConnectingDBToApp.Models;
using ConnectingDBToApp.Commands;
using ConnectingDBToApp.GlobalClasses;
using System;


namespace ConnectingDBToApp.ViewModels
{
    public class SSMSViewModel : INotifyPropertyChanged
    {
        public List<SSMSElement> CreatingDbItems { get; set; }
        public List<SSMSElement> ConnectionDBItems { get; set; }
        public List<SSMSElement> SQLClientDownloadItems { get; set; }
        public List<SSMSElement> SQLClientConnectionDBItems { get; set; }
        public List<SSMSElement> SQLClientQueryExecutionItems { get; set; }
        public List<SSMSElement> EFCore7Items { get; set; }
        public SSMSViewModel()
        {
            CreatingDbItems = DbContext.Tables.SSMSElements
                                               .Where(item => item.Chapter == "CreatingDB")
                                               .ToList();

            ConnectionDBItems = DbContext.Tables.SSMSElements
                                                 .Where(item => item.Chapter == "ConnectionDB")
                                                 .ToList();

            SQLClientDownloadItems = DbContext.Tables.SSMSElements
                                                      .Where(item => item.Chapter == "SQLClientDownload")
                                                      .ToList();

            SQLClientConnectionDBItems = DbContext.Tables.SSMSElements
                                                          .Where(item => item.Chapter == "SQLClientConnectionDB")
                                                          .ToList();

            SQLClientQueryExecutionItems = DbContext.Tables.SSMSElements
                                                            .Where(item => item.Chapter == "SQLClientQueryExecution")
                                                            .ToList();

            EFCore7Items = DbContext.Tables.SSMSElements
                                            .Where(item => item.Chapter == "EFCore7")
                                            .ToList();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static ICommand CopyText =>
            new DelegateCommand(execute: (code) => Clipboard.SetText((string)code));

        public ICommand NavigatePartCommand =>
            new DelegateCommand(
                execute: (index) =>
                {
                    var i = Convert.ToInt32(index);
                    GlobalObjs.SMMSTabControl.SelectedIndex = i;
                    GlobalObjs.MainScrollViewer.ScrollToHome();
                }
            );

        public ICommand NavigateSubPartCommand =>
            new DelegateCommand(
                execute: (index) =>
                {
                    var i = Convert.ToInt32(index);
                    GlobalObjs.SMMSSubTabControl.SelectedIndex = i;
                    GlobalObjs.MainScrollViewer.ScrollToHome();
                }
            );
    }
}
