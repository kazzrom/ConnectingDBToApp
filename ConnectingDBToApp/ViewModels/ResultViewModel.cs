using ConnectingDBToApp.Commands;
using ConnectingDBToApp.GlobalClasses;
using ConnectingDBToApp.Models;
using ConnectingDBToApp.Views.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ConnectingDBToApp.ViewModels
{
    public class ResultViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private TestResult _result = GlobalObjs.Result;
        public TestResult Result
        {
            get => _result;
            set
            {
                _result = value;
                OnPropertyChanged(nameof(Result));
            }
        }

        public ICommand NavigateTestPage =>
            new DelegateCommand(
                execute: (obj) => 
                { 
                    GlobalObjs.MainFrame.Navigate(new TestPage()); 
                }
            );
    }
}
