using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media.Animation;

using ConnectingDBToApp.Models;
using ConnectingDBToApp.Commands;
using ConnectingDBToApp.GlobalClasses;
using ConnectingDBToApp.Views.Pages;


namespace ConnectingDBToApp.ViewModels
{
    public class QuestionViewModel : INotifyPropertyChanged
    {
        private int _countQuestions;
        private int _countRightAnswers;
        public Queue<TestQuestion> TestQuestions { get; set; }

        public QuestionViewModel()
        {
            TestQuestions = new Queue<TestQuestion>(DbContext.Tables.TestQuestions);
            _countQuestions = TestQuestions.Count;
            _countRightAnswers = 0;
            CurrentQuestion = TestQuestions.Dequeue();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private TestQuestion _currentQuestion;
        public TestQuestion CurrentQuestion
        {
            get { return _currentQuestion; }
            set 
            { 
                _currentQuestion = value; 
                OnPropertyChanged(nameof(CurrentQuestion));
            }
        }

        private RadioButton _selectedRadioButton;
        public RadioButton SelectedRadioButton
        {
            get => _selectedRadioButton;
            set
            {
                _selectedRadioButton = value;
                OnPropertyChanged(nameof(SelectedRadioButton));
            }
        }

        private string _buttonContent = "Далее";
        public string ButtonContent
        {
            get => _buttonContent;
            set
            {
                _buttonContent = value;
                OnPropertyChanged(nameof(ButtonContent));
            }
        }

        public ICommand CheckedRadioButton =>
            new DelegateCommand(
                execute: (radioButton) =>
                {
                    SelectedRadioButton = (RadioButton)radioButton;
                }
            );

        public ICommand NextQuestion =>
            new DelegateCommand(
                execute: (obj) =>
                {
                    string selectedAnswer = SelectedRadioButton.Content.ToString()!;
                    ButtonContent = "Далее";

                    if (selectedAnswer == CurrentQuestion.RightAnswer)
                    {
                        _countRightAnswers++;
                    }

                    if (TestQuestions.Count >= 1) 
                    {
                        if(TestQuestions.Count == 1)
                            ButtonContent = "Завершить";
                        CurrentQuestion = TestQuestions.Dequeue();
                        var button = (Button)obj;
                        SelectedRadioButton.IsChecked = false;
                        SelectedRadioButton = null!;
                    }
                    else
                    {
                        GlobalObjs.Result.CountRightAnswer = _countRightAnswers;
                        GlobalObjs.Result.CountQuestions = _countQuestions;
                        GlobalObjs.Result.Percentages = _countRightAnswers * 1.0 / _countQuestions;
                        DbContext.Tables.Add(GlobalObjs.Result);
                        DbContext.Tables.SaveChanges();

                        GlobalObjs.MainFrame.Navigate(new ResultPage());

                        DoubleAnimation animation = new DoubleAnimation()
                        {
                            To = 230,
                            Duration = TimeSpan.FromMilliseconds(200)
                        };
                        animation.EasingFunction = new QuadraticEase() { EasingMode = EasingMode.EaseOut };
                        GlobalObjs.SideBar.BeginAnimation(FrameworkElement.WidthProperty, animation);

                        GlobalObjs.MenuButton.IsEnabled = true;
                    }
                }, 
                canExecute: (obj) =>
                {
                    return SelectedRadioButton != null;
                }
            );
    }
}
