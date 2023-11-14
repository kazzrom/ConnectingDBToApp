using ConnectingDBToApp.Commands;
using ConnectingDBToApp.GlobalClasses;
using ConnectingDBToApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ConnectingDBToApp.ViewModels
{
    public class AllResultsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<TestResult> Results { get; set; } = null!;

        public AllResultsViewModel() 
        { 
            Results = new ObservableCollection<TestResult>(DbContext.Tables.TestResults);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand BackPage =>
            new DelegateCommand(
                execute: (obj) =>
                {
                    GlobalObjs.MainFrame.GoBack();
                }
            );
    }
}
