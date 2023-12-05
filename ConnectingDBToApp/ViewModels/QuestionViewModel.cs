using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.ComponentModel;

using ConnectingDBToApp.Models;
using ConnectingDBToApp.Messages;
using ConnectingDBToApp.GlobalClasses;
using ConnectingDBToApp.Views.Pages;


namespace ConnectingDBToApp.ViewModels
{
    public partial class QuestionViewModel : ObservableObject, IRecipient<GetUsernameMessage>
    {
        private int _countQuestions;
        private int _countRightAnswers;
        private string _username;

        public Queue<TestQuestion> TestQuestions { get; set; }

        public QuestionViewModel()
        {
            _countRightAnswers = 0;
            _username = string.Empty;
            WeakReferenceMessenger.Default.Register(this);
            TestQuestions = new Queue<TestQuestion>(DbContext.Tables.TestQuestions);
            _countQuestions = TestQuestions.Count;
            CurrentQuestion = TestQuestions.Dequeue();
        }

        public void Receive(GetUsernameMessage message)
        {
            _username = message.Value;
            WeakReferenceMessenger.Default.UnregisterAll(this);
        }

        [ObservableProperty]
        private TestQuestion _currentQuestion;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(NextQuestionCommand))]
        private RadioButton _selectedRadioButton = null!;

        [ObservableProperty]
        private string _buttonContent = "Далее";

        [RelayCommand]
        private void CheckedRadioButton(RadioButton radioButton)
        {
            SelectedRadioButton = radioButton;
        }

        [RelayCommand(CanExecute = nameof(CanNextQuestion))]
        private void NextQuestion()
        {
            string selectedAnswer = SelectedRadioButton.Content.ToString()!;

            if (selectedAnswer == CurrentQuestion.RightAnswer)
            {
                _countRightAnswers++;
            }

            if (TestQuestions.Count >= 1)
            {
                if (TestQuestions.Count == 1)
                    ButtonContent = "Завершить";
                CurrentQuestion = TestQuestions.Dequeue();
                SelectedRadioButton.IsChecked = false;
                SelectedRadioButton = null!;
            }
            else
            {
                var result = new TestResult()
                {
                    Username = _username,
                    CountRightAnswer = _countRightAnswers,
                    CountQuestions = _countQuestions,
                    Percentages = _countRightAnswers * 1.0 / _countQuestions
                };

                DbContext.Tables.Add(result);
                DbContext.Tables.SaveChanges();

                GlobalObjs.MainFrame.Navigate(new ResultPage());
                WeakReferenceMessenger.Default.Send(new GetTestResultMessage(result));

                DoubleAnimation animation = new DoubleAnimation()
                {
                    To = 230,
                    Duration = TimeSpan.FromMilliseconds(200)
                };
                animation.EasingFunction = new QuadraticEase() { EasingMode = EasingMode.EaseOut };
                GlobalObjs.SideBar.BeginAnimation(FrameworkElement.WidthProperty, animation);
                GlobalObjs.MenuButton.IsEnabled = true;
            }
        }

        private bool CanNextQuestion()
        {
            return SelectedRadioButton != null;
        }
    }
}
