﻿using ConnectingDBToApp.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ConnectingDBToApp.Models;
using ConnectingDBToApp.GlobalClasses;
using System.Windows.Controls;
using ConnectingDBToApp.Views.Pages;
using ConnectingDBToApp.ViewModels;
using System.Windows.Media.Animation;
using System.Windows;

namespace ConnectingDBToApp.ViewModels
{
    public class QuestionViewModel : INotifyPropertyChanged
    {
        public Queue<TestQuestion> TestQuestions;
        private int _countQuestions;
        private int _countRightAnswers;

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

        public ICommand CheckedRadioButton =>
            new DelegateCommand(execute: (radioButton) =>
            {
                SelectedRadioButton = (RadioButton)radioButton;
            });

        public ICommand NextQuestion =>
            new DelegateCommand(
                execute: (obj) =>
                {
                    string selectedAnswer = SelectedRadioButton.Content.ToString()!;
                    if (selectedAnswer == CurrentQuestion.RightAnswer)
                    {
                        _countRightAnswers++;
                    }

                    if (TestQuestions.Count >= 1) 
                    {
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

                        GlobalObjs.MainFrame.Navigate(new ResultPage(GlobalObjs.Result));

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
