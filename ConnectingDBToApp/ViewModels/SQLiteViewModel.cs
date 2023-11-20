using ConnectingDBToApp.Commands;
using ConnectingDBToApp.GlobalClasses;
using ConnectingDBToApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ConnectingDBToApp.ViewModels
{
    public class SQLiteViewModel : INotifyPropertyChanged
    {
        public List<SQLiteElement> CreatingDbItems { get; set; }
        public List<SQLiteElement> EFCoreConnectingDbItems { get; set; }
        public SQLiteViewModel()
        {
            CreatingDbItems = DbContext.Tables.SQLiteElements
                                               .Where(item => item.Chapter == "CreatingDB")
                                               .ToList();

            EFCoreConnectingDbItems = DbContext.Tables.SQLiteElements
                                                       .Where(item => item.Chapter == "EFCoreConnectingDB")
                                                       .ToList();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static ICommand CopyText => 
            new DelegateCommand(execute: (code) => { Clipboard.SetText((string)code); });

        public static ICommand NavigateLink =>
            new DelegateCommand(execute: (link) => { Process.Start(new ProcessStartInfo((string)link) { UseShellExecute = true }); });
    }
}
