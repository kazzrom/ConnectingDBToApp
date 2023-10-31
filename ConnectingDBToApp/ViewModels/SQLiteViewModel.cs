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
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<SqliteElement> CreatingDbItems { get; set; }
        public ObservableCollection<SqliteElement> EFCoreConnectingDb { get; set; }

        public SQLiteViewModel() 
        {
            CreatingDbItems = new ObservableCollection<SqliteElement>(DbContext.Tables.SqliteElements
                                                                                       .Where(item => item.Chapter == "CreatingDB"));

            EFCoreConnectingDb = new ObservableCollection<SqliteElement>(DbContext.Tables.SqliteElements
                                                                                       .Where(item => item.Chapter == "EFCoreConnectingDB"));
        }
    }
}
