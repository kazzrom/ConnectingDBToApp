using System;
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
        public ObservableCollection<SsmsElement> CreatingDbItems { get; set; }
        public SSMSViewModel() 
        {
            CreatingDbItems = new ObservableCollection<SsmsElement>(DbContext.Tables.Ssmselements
                                                                                     .Where(item => item.Chapter == "CreatingDB"));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
