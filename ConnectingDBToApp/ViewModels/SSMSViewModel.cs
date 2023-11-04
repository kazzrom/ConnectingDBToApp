﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ConnectingDBToApp.Commands;
using ConnectingDBToApp.GlobalClasses;
using ConnectingDBToApp.Models;


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
            CreatingDbItems = DbContext.Tables.SsmsElements
                                               .Where(item => item.Chapter == "CreatingDB")
                                               .ToList();

            ConnectionDBItems = DbContext.Tables.SsmsElements
                                                 .Where(item => item.Chapter == "ConnectionDB")
                                                 .ToList();

            SQLClientDownloadItems = DbContext.Tables.SsmsElements
                                                      .Where(item => item.Chapter == "SQLClientDownload")
                                                      .ToList();

            SQLClientConnectionDBItems = DbContext.Tables.SsmsElements
                                                          .Where(item => item.Chapter == "SQLClientConnectionDB")
                                                          .ToList();

            SQLClientQueryExecutionItems = DbContext.Tables.SsmsElements
                                                            .Where(item => item.Chapter == "SQLClientQueryExecution")
                                                            .ToList();

            EFCore7Items = DbContext.Tables.SsmsElements
                                            .Where(item => item.Chapter == "EFCore7")
                                            .ToList();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static ICommand CopyText
        {
            get => new DelegateCommand((code) =>
            {
                Clipboard.SetText((string)code);
            });
        }
    }
}
