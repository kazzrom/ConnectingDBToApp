using ConnectingDBToApp.GlobalClasses;
using ConnectingDBToApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectingDBToApp.ViewModels
{
    public class SSMSViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<SsmsElement> SSMSElements { get; set; }
        public SSMSViewModel() 
        {
            SSMSElements = new ObservableCollection<SsmsElement>(DbContext.Tables.Ssmselements.ToList());
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
